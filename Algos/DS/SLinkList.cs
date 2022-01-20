using System;

namespace Algos
{
    public class SLinkList<T> // T can be string etc.
    {
        public SNode<T> First;
        public SNode<T> Last;
        public int Count() {
                int cnt = 0;
                var curNode = First;
                while (curNode != null)
                {
                    cnt++;
                    curNode = curNode.Next;
                }

                return cnt;
            }
        public bool IsEmpty { get => First == null; }

        public void AddFirst(T value)
        {
            var newNode = new SNode<T>(value);

            if (IsEmpty)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }
        }
        public void AddLast(T value)
        {
            var newNode = new SNode<T>(value);

            if (IsEmpty)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
        }

        public void DeleteFirst()
        {
            First = First.Next;
        }

        public void DeleteLast()
        {
            var lastNode = First;
            var newLastNode = First;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
                newLastNode = lastNode;
            }

            if (lastNode == newLastNode)
            {
                First = null;
                Last = null;
            }
            else
            {
                newLastNode.Next = null;
                Last = newLastNode;
            }
        }
        public bool Contains(T item)
        {
            if (IsEmpty) return false;

            var curNode = First;
            while (curNode != null)
            {
                if (curNode.Value.Equals(item))
                {
                    return true;
                }

                curNode = curNode.Next;
            }

            return false;
        }

        public void Print()
        {
            var curNode = First;
            while (curNode != null)
            {
                Console.WriteLine($"{curNode.Value}");

                curNode = curNode.Next;
            }
        }

        public int IndexOf(T item)
        {
            if (IsEmpty) return -1;
            int index = -1;

            var curNode = First;
            while (curNode != null)
            {
                index++;
                if (curNode.Value.Equals(item))
                {
                    return index;
                }

                curNode = curNode.Next;
            }

            return index;
        }
    }

    public class SNode<T>
    {
        public T Value { get; set; }
        public SNode<T> Next { get; set; }

        public SNode()
        {

        }
        public SNode(T value)
        {
            Value = value;
        }

        public SNode(T value, SNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
