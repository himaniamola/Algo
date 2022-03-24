using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algos
{
    class Program
    {
        static int[] ids = { 17, 32, 89, 1, 43, 67, 79, 28, 53, 92, 4, 13, 96, 41 };
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //LinkedListOps();
            //MergeSortOps();
            //QuickSortOps();
            //BinaryTreeSearchOps();
            //BinaryGapOp(1041);
            BinaryGapAlt(1041);
            //CyclicRotationOps();
            //OddOccurenceOps();
            //FrogJumpOps(10, 85, 30);
            //TapeEquilibriumOps();
            //PermMissingElemOps();
            /************************************************************/
            //int[] input = { 2, 3, 4, 1, 5}; // { 1, 3, 4, 2, 5};//{ 2,1,3,5, 4};
            //Console.WriteLine($"Number of moments: {Task2(input)}");
            /***********************************************************/
            //int[] input1 = { 5, 19, 8, 1 };
            //Console.WriteLine($"Number of filters: {solution(input1)}");
            /***********************************************************/
            //int[] input = { 9, 6, 5, 0, 8, 2, 1, 3 };
            //HeapFunc.BuildMaxHeapify(input);
            sw.Stop();
            Console.WriteLine($"Timing: {sw.Elapsed.TotalSeconds}");
            Console.ReadKey();
        }

        public static int BinaryGapAlt(int N)
        {
            string N_binary = Convert.ToString(N, 2);

            string[] gaps = N_binary.Split('1');

            string max_gap = "";
            int repetitions = (N_binary.EndsWith("1") ? gaps.Length : gaps.Length - 1);
            for (int i = 0; i < repetitions; i++)
            {
                if (gaps[i].Contains("0") && gaps[i].Length > max_gap.Length)
                {
                    max_gap = gaps[i];
                }
            }

            return max_gap.Length;
        }

        public static int Gap2Alt(int N)
        {
            int i = N;
            int max_gap = 0;
            int current_gap = -1;

            while (i > 0)
            {
                if (i % 2 != 0)
                {
                    max_gap = Math.Max(max_gap, current_gap);
                    current_gap = 0;
                }
                else if (current_gap >= 0)
                {
                    current_gap++;
                }

                i >>= 1;
            }

            Console.WriteLine($"Max gap found: {max_gap}");
            return max_gap;

        }

        public static int solution(int[] A)
        {
            if (A == null)
            {
                return 0;
            }

            int len = A.Length;
            if (len == 0)
            {
                return 0;
            }

            if ((len == 1))
            {
                return 1;
            }

            int numOfFilters = 0;
            decimal totalPollution = 0, halfPol=0;

            for (int i = 0; i < len; i++)
            {
                totalPollution += A[i];
            }
            halfPol = totalPollution / 2;

            bool isPollutionHalfOrLess = false;
            decimal[] arr = new decimal[A.Length];
            for (int i = 0; i < len; i++)
            {
                arr[i] = A[i];
            }
            
            while (!isPollutionHalfOrLess)
            {
                HeapFunc.BuildMaxHeapify(arr);
                decimal reducedPol = (arr[0] / 2);
                arr[0] = reducedPol;
                totalPollution = totalPollution - reducedPol;
                numOfFilters++;
                if (totalPollution <= halfPol)
                {
                    isPollutionHalfOrLess = true;
                }
            }

                return numOfFilters;
        }

        private static void SortArrayInDesc(decimal[] A, int start, int end)
        {
            if (start < end)
            {
                // Find the middle element
                int middle = start + (end - start) / 2;

                // Sort 
                SortArrayInDesc(A, start, middle);
                SortArrayInDesc(A, middle + 1, end);

                // Merge the sorted halves
                Merge(A, start, middle, end);
            }
        }


        private static void Merge(decimal[] arr, int start, int mid, int end)
        {
            // Find sizes
            int cntArrLeft = mid - start + 1;
            int cntArrRight = end - mid;

            // Create temp arrays
            decimal[] leftArr = new decimal[cntArrLeft];
            decimal[] rightArr = new decimal[cntArrRight];
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
                if (leftArr[leftIndex] > rightArr[rightIndex])
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


        public static int Task2(int[] A)
        {
            if((A==null) || (A.Length==0))
            {
                return 0;
            }

            int moments = 0, len = A.Length;
            if((len == 1))
            {
                if (A[0] == 1) moments = 1;
                return moments;
            }

            //bool[] occurence = new bool[len];
            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            for (int i = 0; i < len; i++)
            {
                int val = A[i];
                if (!seen.ContainsKey(val))
                {
                    seen.Add(val, true);
                }
                //occurence[val - 1] = true;
                if ((i + 1) >= val)
                {
                    bool isMoment = true;
                    //for (int j = 0; j < i; j++)
                    //{
                    //    if (!occurence[j])
                    //    {
                    //        isMoment = false;
                    //    }
                    //}

                    for (int j = 1; j < i; j++)
                    {
                        if (!seen.ContainsKey(A[j]))
                        {
                            isMoment = false;
                        }
                    }

                    if (isMoment) moments++;
                }
            }

            return moments;
        }

        private static void PermMissingElemOps()
        {
            int[] val = { 2, 3, 1 ,5 };
            Console.WriteLine($"Perm Missing Element: {TestClass.PermMissingElem(val)}");
        }

        private static void TapeEquilibriumOps()
        {
            int[] val = { 3, 1, 2, 4, 3 };
            Console.WriteLine($"Tape Equilibrium Min Diff: {TestClass.TapeEquilibrium(val)}");
        }

        private static void FrogJumpOps(int X, int Y, int d)
        {
            Console.WriteLine($"Frog Jumps needed to go from {X} to {Y} with step size {d}: {TestClass.FrogJmp(X, Y, d)}");
        }

        private static void OddOccurenceOps()
        {
            int[] val = { 9, 3, 9, 3, 9, 7, 9 };
            Console.WriteLine($"Odd number: {TestClass.OddOccurencesInArray(val)}");
        }

        private static void CyclicRotationOps()
        {
            int[] input = { 1, 2, 3, 4 }; // { 0, 0, 0};// { 3, 8, 9, 7, 6 };
            int[] output = TestClass.CyclicRotation(input, 4);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine($"{output[i]},");
            }
        }

        private static void BinaryGapOp(int val)
        {
            int result = TestClass.BinaryGap(val);
            if (result == 0)
                Console.WriteLine("BinaryyGap not present");
            else
                Console.WriteLine("BinaryGap found of length " + result);
        }

        private static void BinaryTreeSearchOps()
        {
            QuickSort.Sort(ids, 0, ids.Length - 1);
            int result = BinaryTreeSearch.SearchRecur(ids, 0, ids.Length - 1, 79);

            if (result == -1)
                Console.WriteLine("Element not present");
            else
                Console.WriteLine("Element found at index " + result);
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
