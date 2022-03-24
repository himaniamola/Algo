using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public class SMinHeap
    {
        private readonly int[] _elements;
        private int _size;

        public SMinHeap(int size)
        {
            _elements = new int[size];
        }

        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }
        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Peek()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            return _elements[0];
        }

        public int Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException();

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
                throw new IndexOutOfRangeException();

            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && _elements[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }

    public static class HeapFunc
    {
        public static void BuildMaxHeapify(decimal[] arr)
        {
            int len = arr.Length / 2;

            for (int i = len; i > 0; i--)
            {
                MaxHeapify(arr, i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} | ");
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public static void BuildMaxHeapify(int[] arr)
        {
            int len = arr.Length / 2;

            for (int i = len; i > 0; i--)
            {
                MaxHeapify(arr, i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} | ");
            }
        }

        private static void MaxHeapify(int[] arr, int i)
        {
            int left = arr[i * 2-2], right = arr[i * 2 - 1];
            int ele = arr[i-1];

            if(ele < left)
            {
                if (left < right)
                {
                    int temp = ele;
                    arr[i - 1] = right;
                    arr[i * 2 - 1] = temp;
                }
                else
                {
                    int temp = ele;
                    arr[i - 1] = left;
                    arr[i * 2 - 2] = temp;
                }
            }
            else if(ele < right)
            {
                int temp = ele;
                arr[i - 1] = right;
                arr[i * 2 - 1] = temp;
            }
        }

        private static void MaxHeapify(decimal[] arr, int i)
        {
            decimal left = arr[i * 2 - 2], right = arr[i * 2 - 1];
            decimal ele = arr[i - 1];

            if (ele < left)
            {
                if (left < right)
                {
                    decimal temp = ele;
                    arr[i - 1] = right;
                    arr[i * 2 - 1] = temp;
                }
                else
                {
                    decimal temp = ele;
                    arr[i - 1] = left;
                    arr[i * 2 - 2] = temp;
                }
            }
            else if (ele < right)
            {
                decimal temp = ele;
                arr[i - 1] = right;
                arr[i * 2 - 1] = temp;
            }
        }
    }
}
