using System;
using System.Collections;
using System.Collections.Generic;

namespace E08.GeneicLinkedListEnumerable
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            if (Count != 0)
            {
                Node<T> newHead = new Node<T>(element);
                newHead.NextNode = Head;
                Head.PreviousNode = newHead;
                Head = newHead;
            }
            else Head = Tail = new Node<T>(element);

            Count++;
        }

        public void AddLast(T element)
        {
            if (Count != 0)
            {
                Node<T> newTail = new Node<T>(element);
                newTail.PreviousNode = Tail;
                Tail.NextNode = newTail;
                Tail = newTail;
            }
            else Head = Tail = new Node<T>(element);

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0) throw new InvalidOperationException("The list is empty");

            T first = Head.Value;
            Head = Head.NextNode;

            if (Head != null) Head.PreviousNode = null;
            else Tail = null;
            Count--;

            return first;
        }

        public T RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException("The list is empty");

            T last = Tail.Value;
            Tail = Tail.PreviousNode;

            if (Tail != null) Head.NextNode = null;
            else Head = null;
            Count--;

            return last;
        }

        public void ForEach(Action<T> callback)
        {
            Node<T> node = Head;
            while (node != null)
            {
                callback(node.Value);
                node = node.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            int idx = 0;
            Node<T> node = Head;
            while (node != null)
            {
                array[idx++] = node.Value;
                node = node.NextNode;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
