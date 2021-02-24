using System;
using System.Collections.Generic;
using System.Text;

namespace SortLibrary
{
    public class InputData
    {
        public string Description => "This is the class used to deserialize the body from the HTTP request";

        public int[] data { get; set; }
    }
}
