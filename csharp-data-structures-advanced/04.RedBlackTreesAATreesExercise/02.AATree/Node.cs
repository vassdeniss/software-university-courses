using System;

namespace _02.AA_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T element)
        {
            this.Element = element;
            this.Level = 1;
        }

        public T Element { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Left { get; set; }

        public int Level { get; set; }
    }
}