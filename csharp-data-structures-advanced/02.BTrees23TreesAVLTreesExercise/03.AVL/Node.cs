using System;

namespace _03.AVL
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Height = 1;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int Height { get; set; }
    }
}
