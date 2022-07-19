using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Hierarchy
{
    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }

            public T Value { get; }

            public List<Node> Children { get; }
        }

        private readonly Node root;
        private readonly Dictionary<T, Node> valueNode;
        private readonly Dictionary<T, Node> valueParent;

        public Hierarchy(T value)
        {
            this.root = new Node(value);
            this.valueNode = new Dictionary<T, Node>();
            this.valueParent = new Dictionary<T, Node>();

            this.valueNode.Add(value, this.root);
            this.valueParent.Add(value, null);
        }

        public int Count 
            => this.valueNode.Count;

        public void Add(T element, T child)
        {
            // if the parent doesn't exist or the child exists throw exception
            if (!this.valueNode.ContainsKey(element)
                || this.valueNode.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            // Create a node for the child value
            Node childNode = new Node(child);

            // Add the child
            this.valueNode.Add(child, childNode);

            // Add the child-parent relationship
            this.valueParent.Add(child, this.valueNode[element]);  
            
            // Add the parent-child relationship
            this.valueNode[element].Children.Add(childNode);
        }

        public void Remove(T element)
        {
            // If the requested node is the root throw exception
            if (this.root.Value.Equals(element))
            {
                throw new InvalidOperationException();
            }

            // If the requested node doesn't exist throw exception
            if (!this.valueNode.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            // Get the requested node and its parent
            Node parent = this.valueParent[element];
            Node node = this.valueNode[element];

            // Detach parent-child relationship
            parent.Children.Remove(node);
            
            // Add the node children to the parent
            parent.Children.AddRange(node.Children);

            // Fix each node child to the correct parent
            foreach (Node child in node.Children)
            {
                this.valueParent[child.Value] = parent;
            }

            // Remove the requested node
            this.valueNode.Remove(element);
            this.valueParent.Remove(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            // If the element doesn't exist throw exception
            if (!this.valueNode.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            // Get the children values of the element and return them
            return this.valueNode[element].Children
                .Select(node => node.Value)
                .AsEnumerable();
        }

        public T GetParent(T element)
        {
            // If the element doesn't exist throw exception
            if (!this.valueNode.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            // Get the value of the parent
            Node parent = this.valueParent[element];

            // If the value is null
            return parent == null
                // return the default value
                ? default
                // Otherwise return the value
                : parent.Value;
        }

        public bool Contains(T element)
        {
            return this.valueNode.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            return this.valueNode.Keys.Intersect(other.valueNode.Keys);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                yield return current.Value;

                foreach (Node child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
