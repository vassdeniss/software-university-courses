namespace E02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T element)
            {
                Element = element;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newHead = new Node(item);
            Count++;

            if (head == null)
            {
                head = tail = newHead;
                return;
            }

            newHead.Next = head;
            head.Previous = newHead;
            head = newHead;
        }

        public void AddLast(T item)
        {
            Node newTail = new Node(item);
            Count++;

            if (head == null)
            {
                head = tail = newTail;
                return;
            }

            newTail.Previous = tail;
            tail.Next = newTail;
            tail = newTail;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return head.Element;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return tail.Element;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node currHead = head;
            if (head.Next == null)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            Count--;
            return currHead.Element;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            Node currTail = tail;
            if (tail.Previous == null)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            Count--;
            return currTail.Element;
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
