using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class SlidingWindow
    {
        public static int MaxSum(int[] arr, int k)
        {
            int maxSum = 0;
            int len = arr.Length;

            for (int i = 0; i < k; i++)
            {
                maxSum += arr[i];
            }

            int windowSum = maxSum;
            for (int j = k; j < len; j++)
            {
                windowSum += arr[j] - arr[j - k];
                maxSum = Math.Max(maxSum, windowSum);
            }

            return maxSum;
        }
    }
}
