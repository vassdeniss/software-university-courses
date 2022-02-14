namespace L04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            Count++;
            if (head == null)
            {
                head = new Node(item);
                return;
            }

            Node newHead = new Node(item, head);
            head = newHead;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            Node curr = head;
            while (curr.Next != null) curr = curr.Next;
            return curr.Element;
        }

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            Count--;
            if (head.Next == null)
            {
                T el = head.Element;
                head = null;
                return el;
            }

            Node curr = head;
            while (curr.Next.Next != null) curr = curr.Next;

            T element = curr.Next.Element;
            curr.Next = null;
            return element;
        }

        public void Clear()
        {
            Count = 0;
            head = null;
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
