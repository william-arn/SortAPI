using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SortLibrary.Sorts;
using SortLibrary;
using System.Threading;

namespace SortAPI.Handlers
{
    public class SortHandler
    {
        public class NotificationMessage : INotification
        {
            public string NotificationText { get; set; }
        }

        public class Command : IRequest<int[]>
        {
            public int[] _data { get; }
            public SortMethods _method { get; }

            public Command(int[] data, SortMethods method)
            {
                _data = data;
                _method = method;
            }
        }

        public class Handler : IRequestHandler<Command, int[]>
        {
            readonly ILogger _logger;
            readonly IMediator _mediator;

            public Handler(ILogger logger, IMediator mediator)
            {
                _logger = logger;
                _mediator = mediator;
            }

            public async Task<int[]> Handle(Command request, CancellationToken token)
            {
                var data = request._data;
                var method = request._method;
                var result = data;

                try
                {
                    _logger.LogInformation("Start handling data");
                    switch (method)
                    {
                        case SortMethods.BubbleSort:
                            result = BubbleSort.Sort(data);
                            break;
                        case SortMethods.MergeSort:
                            result = MergeSort.Sort(data);
                            break;
                        case SortMethods.QuickSort:
                            result = QuickSort.Sort(data);
                            break;
                        default:
                            throw new Exception("Unrecognized sort type");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error handling data - {e.Message}");
                }
                _logger.LogInformation("End handling data");
                await _mediator.Publish(new NotificationMessage { NotificationText = "Ending Handler in SortHandler.cs" });

                return await Task.FromResult(result);
            }
        }
    }
}
