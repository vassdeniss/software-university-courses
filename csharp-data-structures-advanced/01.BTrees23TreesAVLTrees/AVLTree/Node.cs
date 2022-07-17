using System;

namespace AVLTree
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Height = 1;
            this.Balance = 0;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int Height { get; set; }

        public int Balance { get; set; }
    }
}
