using System;

namespace _01.RedBlackTree
{
    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private Node<T> insertedNode;
        private Node<T> root;

        public RedBlackTree() { }

        private RedBlackTree(Node<T> node)
        {
            PreOrderCopy(node);
        }

        public void Insert(T element)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(element, Color.Black);
                this.root.Count = 1;
                return;
            }

            this.root = Insert(element, this.root);

            if (this.insertedNode != null)
            {
                Rebalance(this.insertedNode);
            }
        }

        public bool Contains(T element)
        {
            return FindElement(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            return new RedBlackTree<T>(FindElement(element));
        }

        public int Count()
        {
            return Count(this.root);
        }

        private Node<T> FindElement(T element)
        {
            Node<T> current = this.root;

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

        private void PreOrderCopy(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                this.insertedNode = new Node<T>(element, Color.Red);
                UpdateCount(this.insertedNode);
                return this.insertedNode;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
                node.Left.Parent = node;
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
                node.Right.Parent = node;
            }

            UpdateCount(node);
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

        private int Count(Node<T> node)
        {
            return node?.Count ?? 0;
        }

        private void Rebalance(Node<T> node)
        {
            // If we reach the root end the re-balancing
            if (node == this.root)
            {
                node.Color = Color.Black;
                return;
            }

            Node<T> parent = node.Parent;
            Node<T> grandParent = node.Parent?.Parent;

            if (!IsRedNode(node) || !IsRedNode(parent)) 
                return;

            // Find the uncle of the violating node
            Node<T> uncle = parent.Value.CompareTo(grandParent.Value) < 0
                ? grandParent.Right
                : grandParent.Left;

            // If the uncle is NILL or the uncle's color is black
            if (uncle == null || uncle.Color == Color.Black)
            {
                // Create a new node for after the rotations
                Node<T> newGrandParent = DetermineRotation(node);

                // If the grandparent was the root of the tree
                // set the new grandparent as the root
                if (grandParent == this.root)
                {
                    this.root = newGrandParent;
                }
                // If the new grand parent is a subtree
                // move it so the regular BST property is saved
                else if (newGrandParent.Value.CompareTo(newGrandParent.Parent.Value) < 0)
                {
                    newGrandParent.Parent.Left = newGrandParent;
                }
                else if (newGrandParent.Value.CompareTo(newGrandParent.Parent.Value) >= 0)
                {
                    newGrandParent.Parent.Right = newGrandParent;
                }

                // Re-Color the old parent / grandparent
                parent.ReColor();
                grandParent.ReColor();

                // Move up the tree
                Rebalance(newGrandParent);
            }
            // The uncle is red
            // Re-Color the three nodes and move up the tree
            else
            {
                uncle.ReColor();
                parent.ReColor();
                grandParent.ReColor();
                Rebalance(grandParent);
            }
        }

        private Node<T> DetermineRotation(Node<T> node)
        {
            Node<T> parent = node.Parent;
            Node<T> grandParent = node.Parent?.Parent;

            Node<T> newGrandParent = grandParent;

            if (parent.Value.CompareTo(node.Value) < 0
                && grandParent.Value.CompareTo(parent.Value) < 0)
            {
                newGrandParent = LeftRotation(grandParent);
            }

            if (parent.Value.CompareTo(node.Value) > 0
                && grandParent.Value.CompareTo(parent.Value) > 0)
            {
                newGrandParent = RightRotation(grandParent);
            }

            if (parent.Value.CompareTo(node.Value) < 0
                && grandParent.Value.CompareTo(parent.Value) > 0)
            {
                newGrandParent = LeftRightRotation(grandParent);
            }

            if (parent.Value.CompareTo(node.Value) > 0
                && grandParent.Value.CompareTo(parent.Value) < 0)
            {
                newGrandParent = RightLeftRotation(grandParent);
            }

            return newGrandParent;
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            // The right child becomes the new parent
            Node<T> newNode = node.Right;

            // Move the new parents left child to be the nodes child
            if (newNode.Left != null)
                newNode.Left.Parent = node;

            // The node's right child overwrites the new parent's left child
            node.Right = newNode.Left;
            // The new parent's left child becomes the node 
            newNode.Left = node;
            // Update the parent relation
            newNode.Parent = node.Parent;
            // Set the node's parent as the new parent
            node.Parent = newNode;

            return newNode;
        }

        private Node<T> RightRotation(Node<T> node)
        {
            // The left child becomes the new parent
            Node<T> newNode = node.Left;

            // Move the new parents right child to be the nodes child
            if (newNode.Right != null)
                newNode.Right.Parent = node;

            // The node's left child overwrites the new parent's right child
            node.Left = newNode.Right;
            // The new parent's right child becomes the node 
            newNode.Right = node;
            // Update the parent relation
            newNode.Parent = node.Parent;
            // Set the node's parent as the new parent
            node.Parent = newNode;

            return newNode;
        }

        private Node<T> RightLeftRotation(Node<T> node)
        {
            // Rotate the right child right
            node.Right = RightRotation(node.Right);
            // Rotate the node left
            return LeftRotation(node);
        }

        private Node<T> LeftRightRotation(Node<T> node)
        {
            // Rotate the left child left
            node.Left = LeftRotation(node.Left);
            // Rotate the node right
            return RightRotation(node);
        }

        private void UpdateCount(Node<T> node)
        {
            node.Count = 1 + Count(node.Left) + Count(node.Right);
        }

        private bool IsRedNode(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            return node.Color == Color.Red;
        }
    }
}
