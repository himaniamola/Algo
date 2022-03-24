using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algos
{
    public static class TestClass
    {
        public static int BinaryGap(int val)
        {
            BitArray ba = new BitArray(BitConverter.GetBytes(val));
            int binaryGap = 0, maxBinaryGap = 0;
            for (int i = 0; i < ba.Length; i++)
            {
                bool currentBit = ba[i];
                if(!currentBit) // current bit is 0
                {
                    if(i>0 && ba[i-1])
                    {
                        binaryGap = 1;
                    }
                    else if (binaryGap > 0)
                    {
                        binaryGap++;
                    }
                }
                else // current bit is 1
                {
                    if (maxBinaryGap < binaryGap)
                    {
                        maxBinaryGap = binaryGap;
                    }
                }
            }

            return maxBinaryGap;
        }

        public static int[] CyclicRotation(int[] input, int k)
        {
            int len = input.Length, i=0;
            int[] result = new int[len];
            int placesToShift = k % len;
            if (placesToShift == 0)
            {
                return input;
            }

            while (placesToShift > 0)
            {
                result[i] = input[k-1+i];
                placesToShift--;
                i++;
            }

            placesToShift = k % len;
            for (int j = 0; j < len - placesToShift; j++)
            {
                int index = (k-1+i+j) % len;
                result[i + j] = input[index]; 
            }

            return result;
        }

        public static int OddOccurencesInArray(int[] input)
        {
            int len = input.Length;
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            int oddOccurence=-1;

            for (int i = 0; i < len; i++)
            {
                int val = input[i];
                if (dict.ContainsKey(val))
                {
                    dict.Remove(val);
                }
                else
                {
                    dict.Add(val, false);
                }
            }

            oddOccurence = dict.Keys.FirstOrDefault();

            return oddOccurence;
        }

        public static int FrogJmp(int X, int Y, int D)
        {
            if(X == Y)
            {
                return 0;
            }

            int jumps = 0;
            decimal diff = (Y - X);
            jumps = Convert.ToInt32(Math.Floor(diff / D));
            if((diff % D) > 0)
            {
                jumps++;
            }

            return jumps;
        }

        public static int TapeEquilibrium(int[] A)
        {
            int len = A.Length;
            if (len == 2)
            {
                return 1;
            }

            int p = 1, sum=0;
            for (int i = 0; i < len; i++)
            {
                sum += A[i];
            }

            int leftSum = A[0], minDiff=0; 
            bool minAbsDiff=false;
            while (!minAbsDiff)
            {
                int prevDiff = Math.Abs(leftSum - sum + leftSum);
                leftSum += A[p];
                int curDiff = Math.Abs(leftSum - sum + leftSum);
                if (prevDiff <= curDiff)
                {
                    minAbsDiff = true;
                    minDiff = prevDiff;
                }
                else
                {
                    p++;
                }
            }

            return minDiff;
        }

        public static int PermMissingElem(int[] inputArr)
        {
            int len = inputArr.Length;
            decimal val = ((len + 2) * (len + 1));
            int totalSum = Convert.ToInt32(val / 2);

            for (int i = 0; i < len; i++)
            {
                totalSum -= inputArr[i];
            }

            return totalSum;
        }
    }
}
