using System;

namespace LinkedListImplementation
{
    public class CustomLinkedList<T>
    {
        private bool isReversed = false;

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddHead(Node<T> node)
        {
            Count++;
            if (DoesFirstExist(node))
            {
                Node<T> prevHead = Head;
                Head = node;
                prevHead.Previous = Head;
                Head.Next = prevHead;
            }
        }

        public void AddTail(Node<T> node)
        {
            Count++;
            if (DoesFirstExist(node))
            {
                Node<T> prevTail = Tail;
                Tail = node;
                prevTail.Next = Tail;
                Tail.Previous = prevTail;
            }
        }

        public Node<T> RemoveHead()
        {
            if (Head == null) return null;

            Count--;
            Node<T> toRemove = Head;
            Node<T> toReplace = Head.Next;
            if (toReplace != null) toReplace.Previous = null;
            else Tail = null;
            Head = toReplace;

            return toRemove;
        }

        public Node<T> RemoveTail()
        {
            if (Tail == null) return null;

            Count--;
            Node<T> toRemove = Tail;
            Node<T> toReplace = Tail.Previous;
            if (toReplace != null) toReplace.Next = null;
            else Head = null;
            Tail = toReplace;

            return toRemove;
        }

        public void ForEach(Action<Node<T>> callback)
        {
            Node<T> node = Head;

            if (isReversed) node = Tail;
            while (node != null)
            {
                callback(node);
                node = isReversed ? node.Previous : node.Next;
            }
        }

        public Node<T>[] ToArray()
        {
            Node<T>[] array = new Node<T>[Count];

            int idx = 0;
            Node<T> node = Head;
            while (node != null)
            {
                array[idx++] = node;
                node = node.Next;
            }

            return array;
        }

        public void Reverse()
        {
            isReversed = !isReversed;
        }

        private bool DoesFirstExist(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return false;
            }

            return true;
        }
    }
}
