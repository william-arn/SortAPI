using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using SortLibrary.Sorts;
using System.Threading;
using SortLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SortAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger _logger;

        public SortsController(IMediator mediator, ILogger<SortsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        
        [HttpPost("Debug")]
        public async Task<ActionResult<int[]>> Debug(
            [FromBody] InputData inputData,
            CancellationToken token)
        {
            var result = await _mediator.Send(new Handlers.SortHandler.Command(inputData.data, SortMethods.BubbleSort), token);
            return new OkObjectResult(result);
        }

        [HttpPost("BubbleSort")]
        public async Task<ActionResult<int[]>> BubbleSort(
            [FromBody] InputData inputData,
            CancellationToken token)
        {
            var result = await _mediator.Send(new Handlers.SortHandler.Command(inputData.data, SortMethods.BubbleSort), token);
            return new OkObjectResult(result);
        }

        [HttpPost("MergeSort")]
        public async Task<ActionResult<int[]>> MergeSort(
            [FromBody] InputData inputData,
            CancellationToken token)
        {
            var result = await _mediator.Send(new Handlers.SortHandler.Command(inputData.data, SortMethods.MergeSort), token);
            return new OkObjectResult(result);
        }

        [HttpPost("QuickSort")]
        public async Task<ActionResult<int[]>> QuickSort(
            [FromBody] InputData inputData,
            CancellationToken token)
        {
            var result = await _mediator.Send(new Handlers.SortHandler.Command(inputData.data, SortMethods.QuickSort), token);
            return new OkObjectResult(result);
        }
    }
}
