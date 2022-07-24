using System;

namespace _01.RedBlackTree
{
    public class Node<T>
    {
        public Node(T value, Color color)
        {
            this.Value = value;
            this.Color = color;
        }

        public Color Color { get; set; }

        public T Value { get; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Parent { get; set; }

        public int Count { get; set; }

        public void ReColor()
        {
            this.Color = (Color)((int)this.Color * -1);
        }
    }
}
