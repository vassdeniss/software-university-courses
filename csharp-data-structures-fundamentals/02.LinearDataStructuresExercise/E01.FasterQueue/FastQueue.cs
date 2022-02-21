namespace E01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Node<T>
    {
        public Node(T element)
        {
            Item = element;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        
        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            Count++;
            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            Node<T> current = tail;
            current.Next = newNode;
            newNode.Previous = current;
            tail = newNode;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T headItem = head.Item;
            Node<T> newHead = head.Next;
            head.Next = null;
            head = newHead;
            tail = null;

            Count--;
            return headItem;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return head.Item;
        }

        public bool Contains(T item)
        {
            Node<T> curr = head;
            while (curr != null)
            {
                if (curr.Item.Equals(item))
                {
                    return true;
                }

                curr = curr.Next;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            int idx = 0;
            foreach (T node in this)
            {
                arr[idx++] = node;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> curr = head;
            while (curr != null)
            {
                yield return curr.Item;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
