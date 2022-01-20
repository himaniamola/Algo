using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class QuickSort
    {
        private static int Partition(int[] arr, int start, int end)
        {
            int pivot;
            pivot = arr[start];
            while (true)
            {
                while (arr[start] < pivot)
                {
                    start++;
                }
                while (arr[end] > pivot)
                {
                    end--;
                }
                if (start < end)
                {
                    int buffer = arr[end];
                    arr[end] = arr[start];
                    arr[start] = buffer;
                }
                else
                {
                    return end;
                }
            }
        }
        public static void Sort(int[] arr, int start, int end)
        {
            int pivot;
            if (start < end)
            {
                pivot = Partition(arr, start, end);
                if (pivot > 1)
                {
                    Sort(arr, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    Sort(arr, pivot + 1, end);
                }
            }
        }

        // print array
        public static void PrintArray(int[] arr)
        {
            int count = arr.Length;
            for (int i = 0; i < count; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
