using System;

namespace AVLTree
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

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(this.Root, action);
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

            UpdateHeight(node);
            UpdateBalance(node);

            return Rebalance(node);
        }

        private Node<T> Rebalance(Node<T> node)
        {
            // Get the node's balance factor
            int balance = GetBalance(node);

            if (balance == -2) // Right child is heavy
            {
                // Get the right child's balance factor
                balance = GetBalance(node.Right);

                node = balance > 0 // Left child is heavy
                    ? RightLeftRotation(node) // Right-Left Case (RL) (Right rotation, left rotation)
                    : RightRightRotation(node); // Right-Right Case (RR) (Left rotation)
            }

            if (balance == 2) // Left child is heavy
            {
                // Get the left child's balance factor
                balance = GetBalance(node.Left);

                node = balance < 0 // Right child is heavy
                    ? LeftRightRotation(node) // Left-Right Case (LR) (Left rotation, right rotation)
                    : LeftLeftRotation(node); // Left-Left Case (LL) (Right rotation)
            }

            return node;
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            // The right child becomes the new parent
            Node<T> newNode = node.Right;
            // The node's right child overwrites the new parent's left child
            node.Right = newNode.Left;
            // The new parent's left child becomes the node 
            newNode.Left = node;

            UpdateHeight(node);
            UpdateHeight(newNode);

            UpdateBalance(node);
            UpdateBalance(newNode);

            return newNode;
        }

        private Node<T> RightRotation(Node<T> node)
        {
            // The left child becomes the new parent
            Node<T> newNode = node.Left;
            // The node's left child overwrites the new parent's right child
            node.Left = newNode.Right;
            // The new parent's right child becomes the node 
            newNode.Right = node;

            UpdateHeight(node);
            UpdateHeight(newNode);

            UpdateBalance(node);
            UpdateBalance(newNode);

            return newNode;
        }

        // Left-Left Case (LL) -> Single right rotation
        private Node<T> LeftLeftRotation(Node<T> node)
        {
            // Rotate the node right
            return RightRotation(node);
        }

        // Right-Left Case (RL) -> One right rotation and one left rotation
        private Node<T> RightLeftRotation(Node<T> node)
        {
            // Rotate the right child right
            node.Right = LeftLeftRotation(node.Right);
            // Rotate the node left
            return RightRightRotation(node);
        }

        // Right-Right Case (RR) -> Single left rotation
        private Node<T> RightRightRotation(Node<T> node)
        {
            // Rotate the node left
            return LeftRotation(node);
        }

        // Left-Right Case (LR) -> One left rotation and one right rotation
        private Node<T> LeftRightRotation(Node<T> node)
        {
            // Rotate the left child left
            node.Left = RightRightRotation(node.Left);
            // Rotate the node right
            return LeftLeftRotation(node);
        }

        private void UpdateBalance(Node<T> node)
        {
            // Get the node's new balance factor by subtracting the left height by the right height
            node.Balance = GetHeight(node.Left) - GetHeight(node.Right);
        }

        private int GetBalance(Node<T> node)
        {
            return node?.Balance ?? 0;
        }

        private void UpdateHeight(Node<T> node)
        {
            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            // Get the node's new height by adding its own height to the bigger height of the left / right child
            node.Height = Math.Max(leftHeight, rightHeight) + 1;
        }

        private int GetHeight(Node<T> node)
        {
            return node?.Height ?? 0;
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
    }
}
