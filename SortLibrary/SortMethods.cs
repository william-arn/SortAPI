using System;

namespace SortLibrary
{
    [Flags]
    public enum SortMethods
    {
        BubbleSort = 1,
        MergeSort = 1 << 1,
        QuickSort = 1 << 2,
    }
}
