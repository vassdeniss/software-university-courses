using System;

namespace _03.AVL
{
    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            Node<T> node = Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = Insert(this.Root, item);
        }

        public void Delete(T key)
        {
            this.Root = Delete(this.Root, key);
        }

        public void DeleteMin()
        {
            this.Root = MinNode(this.Root);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(this.Root, action);
        }

        private Node<T> MinNode(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = MinNode(node.Left);

            UpdateHeight(node);
            node = Balance(node);

            return node;
        }

        private Node<T> Delete(Node<T> node, T key)
        {
            // Step 1: Perform standard BST deletion
            // Step 2: Perform re-balance

            if (node == null)
            {
                return node;
            }

            if (key.CompareTo(node.Value) < 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (key.CompareTo(node.Value) > 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left != null && node.Right != null)
                {
                    Node<T> max = node.Right;
                    while (max.Left != null)
                    {
                        max = max.Left;
                    }

                    node.Value = max.Value;
                    node.Right = Delete(node.Right, max.Value);
                }
                else
                {
                    node = node.Left ?? node.Right;
                }
            }

            if (node == null)
            {
                return node;
            }

            node = Balance(node);
            UpdateHeight(node);

            return node;
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int compareResult = item.CompareTo(node.Value);
            if (compareResult < 0)
            {
                node.Left = Insert(node.Left, item);
            }
            else if (compareResult > 0)
            {
                node.Right = Insert(node.Right, item);
            }

            node = Balance(node);
            UpdateHeight(node);

            return node;
        }

        private Node<T> Balance(Node<T> node)
        {
            int balance = Height(node.Left) - Height(node.Right);
            if (balance > 1)
            {
                int childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balance < -1)
            {
                int childBalance = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int compareResult = item.CompareTo(node.Value);
            if (compareResult < 0)
            {
                return Search(node.Left, item);
            }
            
            if (compareResult > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }

        private int Height(Node<T> node)
        {
            return node?.Height ?? 0;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            Node<T> left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }
    }
}
