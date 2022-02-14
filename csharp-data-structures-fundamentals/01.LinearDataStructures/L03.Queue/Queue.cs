namespace L03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element)
            {
                Element = element;
            }

            public Node(T element, Node next) : this(element)
            {
                Next = next;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Count++;
            if (head == null)
            {
                head = new Node(item);
                return;
            }

            Node curr = head;
            while (curr.Next != null) curr = curr.Next;
            curr.Next = new Node(item);
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            T element = head.Element;
            head = head.Next;
            Count--;
            return element;
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public bool Contains(T item)
        {
            Node curr = head;
            while (curr != null)
            {
                if (curr.Element.Equals(item))
                {
                    return true;
                }

                curr = curr.Next;
            }

            return false;
        }

        public void Clear()
        {
            Count = 0;
            head = null;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            int idx = 0;
            foreach (T item in this)
            {
                arr[idx++] = item;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node curr = head;
            while (curr != null)
            {
                yield return curr.Element;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
