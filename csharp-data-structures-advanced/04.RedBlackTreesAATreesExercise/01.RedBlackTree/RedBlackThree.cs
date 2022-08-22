using System;
using System.Collections.Generic;

namespace _01.RedBlackTree
{
    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private Node root;

        public RedBlackTree()
        {
            
        }

        private RedBlackTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public int Count => this.CountNodes(this.root);

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
            this.root.Color = Color.Black;
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            if (this.IsRed(node.Right))
            {
                node = this.RotateLeft(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.SwapColors(node);
            }

            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);

            return node;
        }

        private Node RotateLeft(Node node)
        {
            Node newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            newNode.Color = newNode.Left.Color;
            newNode.Left.Color = Color.Red;

            newNode.Count = node.Count;
            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);

            return newNode;
        }

        private Node RotateRight(Node node)
        {
            Node newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            newNode.Color = newNode.Right.Color;
            newNode.Right.Color = Color.Red;

            newNode.Count = node.Count;
            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);

            return newNode;
        }

        private void SwapColors(Node node)
        {
            node.Color = node.Color == Color.Red ? Color.Black : Color.Red;
            node.Left.Color = node.Left.Color == Color.Red ? Color.Black : Color.Red;
            node.Right.Color = node.Right.Color == Color.Red ? Color.Black : Color.Red;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Color.Red;
        }

        public T Select(int rank)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            return this.Select(rank, this.root).Value;
        }

        private Node Select(int rank, Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            if (this.CountNodes(node.Left) == rank)
            {
                return node;
            }

            if (this.CountNodes(node.Left) > rank)
            {
                return this.Select(rank, node.Left);
            }

            return this.Select(rank - (this.CountNodes(node.Left) + 1), node.Right);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(element, node.Left);
            }

            if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.CountNodes(node.Left) + this.Rank(element, node.Right);
            }

            return this.CountNodes(node.Left);
        }

        public bool Contains(T element)
        {
            return this.Search(element, this.root) != null;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            return new RedBlackTree<T>(this.Search(element, this.root));
        }

        private Node Search(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Search(element, node.Left);
            }

            if (element.CompareTo(node.Value) > 0)
            {
                return this.Search(element, node.Right);
            }

            return node;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);

            return node;
        }

        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);

            return node;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            Queue<T> queue = new Queue<T>();

            this.Range(this.root, queue, startRange, endRange);

            return queue;
        }

        private void Range(Node node, Queue<T> queue, T startRange, T endRange)
        {
            if (node == null)
            {
                return;
            }

            if (startRange.CompareTo(node.Value) < 0)
            {
                this.Range(node.Left, queue, startRange, endRange);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                queue.Enqueue(node.Value);
            }

            if (endRange.CompareTo(node.Value) > 0)
            {
                this.Range(node.Right, queue, startRange, endRange);
            }
        }

        public void Delete(T element)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.Delete(element, this.root);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                Node copy = node;
                node = this.FindSmallestChild(copy.Right);
                node.Right = this.DeleteMin(copy.Right);
                node.Left = copy.Left;
            }

            node.Count = 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);
            return node;
        }

        private Node FindSmallestChild(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }

            return this.FindSmallestChild(node.Left);
        }

        public T Ceiling(T element)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            return this.Select(this.Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);
            action(node.Value);
            this.EachInOrder(action, node.Right);
        }

        private int CountNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Color.Red;
            }

            public T Value { get; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Count { get; set; }

            public Color Color { get; set; }
        }

        private enum Color
        {
            Black,
            Red
        }
    }
}
