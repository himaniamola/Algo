namespace Algos
{
    public static class BinaryTreeSearch
    {
        public static int SearchRecur(int[] arr, int left, int right, int value)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == value)
                    return mid;

                if (arr[mid] > value)
                    return SearchRecur(arr, left, mid - 1, value);

                return SearchRecur(arr, mid + 1, right, value);
            }

            return -1;
        }

        public static int Search(int[] arr, int valToFind)
        {
            int start = 0, end = arr.Length - 1;

            while(end >= start)
            {
                int midIndex = start + (( end - start )/2);
                int middleVal = arr[midIndex];

                if (middleVal == valToFind)
                {
                    return midIndex;
                }
                else if(middleVal > valToFind)
                {
                    end = midIndex - 1;
                }
                else
                {
                    start = midIndex + 1;
                }

            }

            return -1;
        }

        public static int SearchOrderAgnostic(int[] arr, int valToFind)
        {
            if ((arr == null) || (arr.Length == 0)) return -1; // null or empty array
            int firstElement = arr[0], lastElement = arr[arr.Length-1];
            if (firstElement == lastElement) 
            {
                return (firstElement == valToFind) ? 0 : -1;
            }

            bool isAsc = (firstElement < lastElement) ? true : false;
            int start = 0, end = arr.Length - 1;

            while (end >= start)
            {
                int midIndex = start + ((end - start) / 2);
                int middleVal = arr[midIndex];

                if (middleVal == valToFind)
                {
                    return midIndex;
                }

                if (isAsc)
                {
                    if (middleVal > valToFind)
                    {
                        end = midIndex - 1;
                    }
                    else
                    {
                        start = midIndex + 1;
                    }
                }
                else
                {
                    if (middleVal < valToFind)
                    {
                        end = midIndex - 1;
                    }
                    else
                    {
                        start = midIndex + 1;
                    }
                }
            }

            return -1;
        }
    }
}
