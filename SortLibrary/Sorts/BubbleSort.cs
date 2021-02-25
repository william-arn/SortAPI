using SortLibrary.Functions;
namespace SortLibrary.Sorts
{
    public class BubbleSort : ISort
    {
        public string Description => "Walks through an array looking forward and swaps elements if they are out of order";

        public static int[] Sort(int[] data)
        {
            bool isSorted = false;
            int lastIndex = data.Length - 1;

            while (!isSorted){
                isSorted = true;
                for (int i = 0; i < lastIndex; i++){
                    if (data[i] > data[i + 1]){
                        ArrayFunctions.Swap(data, i, i+1);
                        isSorted = false;
                    }
                }
                lastIndex--;
            }

            return data;
        }
    }
}
