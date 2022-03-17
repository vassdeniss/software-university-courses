namespace L02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            Insert(node.Value);

            if (node.Left != null)
            {
                PreOrderCopy(node.Left);
            }

            if (node.Right != null)
            {
                PreOrderCopy(node.Right);
            }
        }

        public bool Contains(T element)
        {
            return FindNode(element) != null;
        }

        private Node FindNode(T element)
        {
            Node node = root;
            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, root);
        }

        private void EachInOrder(Action<T> action, Node root)
        {
            if (root == null) return;

            if (root.Left != null)
            {
                EachInOrder(action, root.Left);
            }

            action(root.Value);

            if (root.Right != null)
            {
                EachInOrder(action, root.Right);
            }
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node is null)
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

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = FindNode(element);
            if (node == null) return null;
            return new BinarySearchTree<T>(node);
        }
    }
}
