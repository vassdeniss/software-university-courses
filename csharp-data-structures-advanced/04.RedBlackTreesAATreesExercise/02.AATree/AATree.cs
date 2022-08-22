using System;

namespace _02.AA_Tree
{
    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int CountNodes()
        {
            return this.CountNodes(this.root);
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Search(T element)
        {
            Node<T> node = this.root;
            while (node != null)
            {
                if (element.CompareTo(node.Element) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Element) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node != null;
        }

        public void InOrder(Action<T> action)
        {
            this.InOrder(action, this.root);
        }

        public void PreOrder(Action<T> action)
        {
            this.PreOrder(action, this.root);
        }

        public void PostOrder(Action<T> action)
        {
            this.PostOrder(action, this.root);
        }

        private int CountNodes(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else
            {
                node.Right = this.Insert(element, node.Right);
            }

            node = this.Skew(node);
            node = this.Split(node);

            return node;
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Left == null || node.Left.Level != node.Level)
            {
                return node;
            }

            Node<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            node = newNode;

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null || node.Right.Right.Level != node.Level)
            {
                return node;
            }

            Node<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            node = newNode;

            return node;
        }

        private void InOrder(Action<T> action, Node<T> node)
        {
            if (node.Left != null)
            {
                this.InOrder(action, node.Left);
            }

            action(node.Element);

            if (node.Right != null)
            {
                this.InOrder(action, node.Right);
            }
        }

        private void PreOrder(Action<T> action, Node<T> node)
        {
            action(node.Element);

            if (node.Left != null)
            {
                this.PreOrder(action, node.Left);
            }

            if (node.Right != null)
            {
                this.PreOrder(action, node.Right);
            }
        }

        private void PostOrder(Action<T> action, Node<T> node)
        {
            if (node.Left != null)
            {
                this.PostOrder(action, node.Left);
            }

            if (node.Right != null)
            {
                this.PostOrder(action, node.Right);
            }

            action(node.Element);
        }
    }
}
