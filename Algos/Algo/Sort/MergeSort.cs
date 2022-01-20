using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class MergeSort
    {
        private static void Merge(int[] arr, int start, int mid, int end)
        {
            // Find sizes
            int cntArrLeft = mid - start + 1;
            int cntArrRight = end - mid;

            // Create temp arrays
            int[] leftArr = new int[cntArrLeft];
            int[] rightArr = new int[cntArrRight];
            int leftIndex, rightIndex;

            // Copy data to temp arrays
            for (leftIndex = 0; leftIndex < cntArrLeft; ++leftIndex)
                leftArr[leftIndex] = arr[start + leftIndex];
            for (rightIndex = 0; rightIndex < cntArrRight; ++rightIndex)
                rightArr[rightIndex] = arr[mid + 1 + rightIndex];

           
            // Initial indices
            leftIndex = rightIndex = 0;

            // Initial index of merged
            // subarray array
            int sortedArrIndex = start;
            while (leftIndex < cntArrLeft && rightIndex < cntArrRight)
            {
                if (leftArr[leftIndex] <= rightArr[rightIndex])
                {
                    arr[sortedArrIndex] = leftArr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[sortedArrIndex] = rightArr[rightIndex];
                    rightIndex++;
                }
                sortedArrIndex++;
            }

            // Copy remaining elements of leftArr, if any
            while (leftIndex < cntArrLeft)
            {
                arr[sortedArrIndex] = leftArr[leftIndex];
                leftIndex++;
                sortedArrIndex++;
            }

            // Copy remaining elements of rightArr, if any
            while (rightIndex < cntArrRight)
            {
                arr[sortedArrIndex] = rightArr[rightIndex];
                rightIndex++;
                sortedArrIndex++;
            }
        }

        // Sort and Merge
        public static void Sort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                // Find the middle element
                int middle = start + (end - start) / 2;

                // Sort 
                Sort(arr, start, middle);
                Sort(arr, middle + 1, end);

                // Merge the sorted halves
                Merge(arr, start, middle, end);
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
