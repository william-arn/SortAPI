using System;
using System.Collections.Generic;
using System.Text;
using SortLibrary.Functions;

namespace SortLibrary.Sorts
{
    public class QuickSort :ISort
    {
        public string Description => "Sorts elements around a pivot. Called recursively and then applied on either side of the pivot.";

        public static int[] Sort(int[] data)
        {
            QSort(data, 0, data.Length - 1);
            return data;
        }

        private static void QSort(int[] data, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
                return;

            int pivotValue = data[(leftIndex + rightIndex) / 2];
            int index = Partition(data, leftIndex, rightIndex, pivotValue);
            QSort(data, leftIndex, index -1);
            QSort(data, index, rightIndex);
        }

        private static int Partition(int[] data, int leftIndex, int rightIndex, int pivotValue)
        {
            while (leftIndex <= rightIndex){
                while (data[leftIndex] < pivotValue)
                    leftIndex++;

                while (data[rightIndex] > pivotValue)
                    rightIndex--;

                if (leftIndex <= rightIndex)
                    ArrayFunctions.Swap(data, leftIndex++, rightIndex--);
            }

            return leftIndex;
        }
    }
}
