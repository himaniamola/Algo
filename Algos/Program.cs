using System;

namespace Algos
{
    class Program
    {
        static int[] ids = { 17, 32, 89, 1, 43, 67, 79, 28, 53, 92, 4, 13, 96, 41 };
        static void Main(string[] args)
        {
            //LinkedListOps();
            //MergeSortOps();
            QuickSortOps();

            Console.ReadKey();
        }

        private static void QuickSortOps()
        {
            Console.WriteLine("Unsorted Array:");
            QuickSort.PrintArray(ids);
            QuickSort.Sort(ids, 0, ids.Length - 1);
            Console.WriteLine("Sorted Array:");
            QuickSort.PrintArray(ids);
        }

        private static void MergeSortOps()
        {
            Console.WriteLine("Unsorted Array:");
            MergeSort.PrintArray(ids);
            MergeSort.Sort(ids, 0, ids.Length - 1);
            Console.WriteLine("Sorted Array:");
            MergeSort.PrintArray(ids);
        }

        private static void LinkedListOps()
        {
            SLinkList<string> newLL = new SLinkList<string>();
            newLL.AddLast("One");
            newLL.AddLast("Two");
            newLL.Print();
            Console.WriteLine($"Contains value 'Two': {newLL.Contains("Two")}");
        }
    }
}
