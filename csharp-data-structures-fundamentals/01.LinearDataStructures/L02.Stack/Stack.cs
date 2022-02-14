namespace L02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node newTop = new Node(item, top);
            top = newTop;
            Count++;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T element = top.Element;
            top = top.Next;
            Count--;

            return element;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return top.Element;
        }

        public bool Contains(T item)
        {
            Node curr = top;
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
            top = null;
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
            Node curr = top;
            while (curr != null)
            {
                yield return curr.Element;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
