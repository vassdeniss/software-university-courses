namespace E01.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            PreOrderCopy(node);
        }

        public BinarySearchTree() { }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        public bool Contains(T element)
        {
            Node current = FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            if (root is null)
            {
                throw new InvalidOperationException();
            }

            root = Delete(root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node is null) return node;

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Left is null && node.Right is null)
                {
                    node = null;
                }
                else if (node.Left != null && node.Right != null)
                {
                    Node max = node.Right;
                    while (max.Left != null)
                    {
                        max = max.Left;
                    }

                    node.Value = max.Value;
                    node.Right = Delete(node.Right, max.Value);
                }
                else node = node.Left ?? node.Right;
            }

            return node;
        }

        public void DeleteMax()
        {
            if (root is null)
            {
                throw new InvalidOperationException();
            }

            root = MaxNode(root);
        }

        private Node MaxNode(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = MaxNode(node.Right);
            node.Count = 1 + Count(node.Left) + Count(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (root is null)
            {
                throw new InvalidOperationException();
            }

            root = MinNode(root);
        }

        private Node MinNode(Node node)
        { 
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = MinNode(node.Left);
            node.Count = 1 + Count(node.Left) + Count(node.Right);

            return node;
        }

        public int Count()
        {
            return Count(root);
        }

        private int Count(Node node)
        {
            if (node is null) return 0;
            return node.Count;
        }

        public int Rank(T element)
        {
            return GetRank(root, element);
        }

        private int GetRank(Node node, T element)
        {
            if (node is null) return 0;

            if (element.CompareTo(node.Value) < 0)
            {
                return GetRank(node.Left, element);
            }

            if (element.CompareTo(node.Value) > 0)
            {
                return 1 + Count(node.Left) + GetRank(node.Right, element);
            }

            return Count(node.Left);
        }

        public T Select(int rank)
        {
            if (root is null)
            {
                throw new InvalidOperationException();
            }

            Node node = Select(root, rank);
            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node is null)
            {
                throw new InvalidOperationException();
            }

            int leftNodes = Count(node.Left);
            if (leftNodes == rank)
            {
                return node;
            }
            else if (leftNodes > rank) 
            {
                return Select(node.Left, rank);
            }
            else
            {
                return Select(node.Right, rank - (leftNodes + 1));
            }
        }

        public T Ceiling(T element)
        {
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return Select(Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            Queue<T> queue = new Queue<T>();
            GetRange(root, startRange, endRange, queue);
            return queue;
        }

        private void GetRange(Node node, T startRange, T endRange, Queue<T> queue)
        {
            if (node is null) return;

            if (startRange.CompareTo(node.Value) < 0)
            {
                GetRange(node.Left, startRange, endRange, queue);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                queue.Enqueue(node.Value);
            }

            if (endRange.CompareTo(node.Value) > 0)
            {
                GetRange(node.Right, startRange, endRange, queue);
            }
        }

        private Node FindElement(T element)
        {
            Node current = root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            node.Count = 1 + Count(node);

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
    }
}
