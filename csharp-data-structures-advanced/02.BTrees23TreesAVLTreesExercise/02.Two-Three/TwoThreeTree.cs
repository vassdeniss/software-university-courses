using System;
using System.Text;

namespace _02.Two_Three
{
    public class TwoThreeTree<T> 
        where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(key);
                return;
            }

            this.root = Insert(this.root, key);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T newElement)
        {
            if (node.IsLeaf())
            {
                return MergeNewElement(node, new TreeNode<T>(newElement));
            }

            TreeNode<T> resultNode;
            if (newElement.CompareTo(node.LeftKey) < 0)
            {
                resultNode = Insert(node.LeftChild, newElement);
                if (resultNode == node.LeftChild)
                {
                    return node;
                }

                return MergeNewElement(node, resultNode);
            }
            
            if (newElement.CompareTo(node.RightKey) < 0 || node.IsTwoNode())
            {
                resultNode = Insert(node.MiddleChild, newElement);
                if (resultNode == node.MiddleChild)
                {
                    return node;
                }

                return MergeNewElement(node, resultNode);
            }

            resultNode = Insert(node.RightChild, newElement);
            if (resultNode == node.RightChild)
            {
                return node;
            }

            return MergeNewElement(node, resultNode);
        }

        private TreeNode<T> MergeNewElement(TreeNode<T> currentNode, TreeNode<T> nodeToInsert)
        {
            // Current node has 1-key-2-child
            if (currentNode.IsTwoNode())
            {
                // New element must be inserted on right side
                if (currentNode.LeftKey.CompareTo(nodeToInsert.LeftKey) < 0)
                {
                    // Insert the new elements key to the right of the current node
                    currentNode.RightKey = nodeToInsert.LeftKey;
                    // Insert the new elements left child as the middle child
                    currentNode.MiddleChild = nodeToInsert.LeftChild;
                    // Insert the new elements middle child as the right child
                    currentNode.RightChild = nodeToInsert.MiddleChild;
                }
                else // New element must be inserted on left side
                {
                    // Put the left key as right to make room to insert the new one
                    currentNode.RightKey = currentNode.LeftKey;
                    // Switch the middle child to be right child
                    currentNode.RightChild = currentNode.MiddleChild;
                    // Insert the new element as left key
                    currentNode.LeftKey = nodeToInsert.LeftKey;
                    // Insert the new elements middle child on the place of the old middle child
                    currentNode.MiddleChild = nodeToInsert.MiddleChild;
                }

                return currentNode;
            }
            
            // Current node has 2-key-3-child (needs promotion)
            // New node has to be inserted to the left
            if (currentNode.LeftKey.CompareTo(nodeToInsert.LeftKey) >= 0)
            {
                // Create another new node with a copy of our current left key
                TreeNode<T> newNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    // Set the left child as the node we want to insert
                    LeftChild = nodeToInsert,
                    // Set the middle as our current node
                    MiddleChild = currentNode
                };

                // Move the current left child over to the inserted node
                nodeToInsert.LeftChild = currentNode.LeftChild;
                // Move the current middle child to be the left child
                currentNode.LeftChild = currentNode.MiddleChild;
                // Remove the right child
                currentNode.RightChild = null;
                // Overwrite the left key with the right key
                // Note: The left key was promoted as 'newNode'
                currentNode.LeftKey = currentNode.RightKey;
                // Remove the right key 
                currentNode.RightChild = default;

                return newNode;
            }

            // Current node has 2-key-3-child (needs promotion)
            // New node is inserted in the middle and promoted
            if (currentNode.RightKey.CompareTo(nodeToInsert.LeftKey) >= 0)
            {
                // The middle child of the node we insert (promote) becomes a new node
                // with our current nodes right key
                nodeToInsert.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    // The middle child of the inserted node becomes its left
                    LeftChild = nodeToInsert.MiddleChild,
                    // The right child of our current node becomes the middle child of the isnerted node
                    MiddleChild = currentNode.RightChild
                };

                // The inserted nodes left child becomes our current node
                nodeToInsert.LeftChild = currentNode;
                // Delete the right key of our new left child
                currentNode.RightKey = default;
                // Delete the right child of our new left child
                currentNode.RightChild = null;

                return nodeToInsert;
            }

            // Current node has 2-key-3-child (needs promotion)
            // New node is inserted in the right and middle is promoted

            // Create another new node with a copy of our current right key
            TreeNode<T> newNode2 = new TreeNode<T>(currentNode.RightKey)
            {
                // Set the left child as the our current node
                LeftChild = currentNode,
                // Set the middle child as the node we want to insert
                MiddleChild = nodeToInsert
            };

            // Move the left child's right child as the middle child's left child
            nodeToInsert.LeftChild = currentNode.RightChild;
            // Delete the middle child's right child
            currentNode.RightChild = null;
            // Delete the middle child's right key
            currentNode.RightKey = default;

            return newNode2;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
