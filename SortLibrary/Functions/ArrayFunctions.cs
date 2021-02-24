using System;
using System.Collections.Generic;
using System.Text;

namespace SortLibrary.Functions
{
    public class ArrayFunctions
    {
        public static void Swap(int[] data, int i, int j)
        {
            var tempData = data[j];
            data[j] = data[i];
            data[i] = tempData;
        }
    }
}
