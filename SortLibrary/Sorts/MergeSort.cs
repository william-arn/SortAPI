using System;

namespace SortLibrary.Sorts
{
    public class MergeSort : ISort
    {
        public string Description => "Sort two halves of the array. Then, merge those halves together.";

        public static int[] Sort (int[] data)
        {
            MSort(data, 0, data.Length - 1);
            return data;
        }

        private static void MSort (int[] data, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            int middle = (leftStart + rightEnd) / 2;
            MSort(data, leftStart, middle);
            MSort(data, middle+1, rightEnd);
            MergeHalves(data, middle, leftStart, rightEnd);
        }

        private static void MergeHalves(int[] data, int middle, int leftStart, int rightEnd)
        {
            int[] leftHalf = new int[middle - leftStart + 1];
            int[] rightHalf = new int[rightEnd - middle];

            Array.Copy(data, leftStart, leftHalf, 0, middle - leftStart+ 1);
            Array.Copy(data, middle + 1, rightHalf, 0, rightEnd - middle);

            int leftIndex = 0;
            int rightIndex = 0;

            //Take lesser of two halves unless one half is empty
            for (int i = leftStart; i < rightEnd + 1; i++){
                if (leftIndex == leftHalf.Length)
                    data[i] = rightHalf[rightIndex++];
                else if (rightIndex == rightHalf.Length)
                    data[i] = leftHalf[leftIndex++];
                else if (leftHalf[leftIndex] <= rightHalf[rightIndex])
                    data[i] = leftHalf[leftIndex++];
                else
                    data[i] = rightHalf[rightIndex++];
            }
        }
    }
}