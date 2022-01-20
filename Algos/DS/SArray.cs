using System;

namespace Algos
{
    public class SArray
    {
        private int[] items;
        private int itemCnt;
        private int maxItemCnt;
        public SArray(int len)
        {
            items = new int[len];
            maxItemCnt = len;
        }

        public void Print()
        {
            for (int i = 0; i < itemCnt; i++)
            {
                Console.WriteLine($"Index: {i}, Value: {items[i]}");
            }
        }

        public void Insert(int newItem)
        {
            if (itemCnt == maxItemCnt) // Array is full so, create a new array
            {
                var newItems = new int[itemCnt*2];
                for (int i = 0; i < itemCnt; i++)
                {
                    newItems[i] = items[i];
                }

                items = newItems;
            }

            items[itemCnt++] = newItem;
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= itemCnt))
            {
                throw new Exception("Index out of range");
            }

            for (int i = index; i < itemCnt; i++)
            {
                items[i] = items[i+1];
            }
        }

        public int IndexOf(int item)
        {
            int index = -1;
            for (int i = 0; i < itemCnt; i++)
            {
                if (items[i] == item)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
