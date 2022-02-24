namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            Value = value;
            children = new List<Tree<T>>();
            IsRootDelete = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();
        public bool IsRootDelete { get; private set; }

        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            if (IsRootDelete) return result;

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                result.Add(subtree.Value);
                foreach (Tree<T> child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();
            if (IsRootDelete) return result;
            DFS(this, result);
            return result;
        }

        private void DFS(Tree<T> tree, List<T> result)
        {
            foreach (Tree<T> child in tree.children)
            {
                DFS(child, result);
            }

            result.Add(tree.Value);
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = FindNodeBFS(parentKey);
            if (parent is null)
            {
                throw new ArgumentNullException();
            }

            child.Parent = parent;
            parent.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> node = FindNodeBFS(nodeKey);
            if (node is null)
            {
                throw new ArgumentNullException();
            }

            if (node.Parent is null) IsRootDelete = true;
            else node.Parent.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> nodeOne = FindNodeBFS(firstKey);
            Tree<T> nodeTwo = FindNodeBFS(secondKey);
            if (nodeOne is null || nodeTwo is null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> parentOne = nodeOne.Parent;
            Tree<T> parentTwo = nodeTwo.Parent;

            if (parentOne is null)
            {
                nodeOne.Value = nodeTwo.Value;
                nodeOne.children.Clear();

                foreach (Tree<T> child in nodeTwo.children)
                {
                    nodeOne.children.Add(child);
                }

                return;
            }

            if (parentTwo is null)
            {
                nodeTwo.Value = nodeOne.Value;
                nodeTwo.children.Clear();

                foreach (Tree<T> child in nodeOne.children)
                {
                    nodeTwo.children.Add(child);
                }

                return;
            }

            nodeOne.Parent = parentTwo;
            nodeTwo.Parent = parentOne;

            int firstChildIdx = parentOne.children.IndexOf(nodeOne);
            int secondChildIdx = parentTwo.children.IndexOf(nodeTwo);

            parentOne.children[firstChildIdx] = nodeTwo;
            parentTwo.children[secondChildIdx] = nodeOne;
        }

        private Tree<T> FindNodeBFS(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                if (subtree.Value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (Tree<T> child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public void PrettyPrintTree(Tree<T> tree, string indent)
        {
            Console.WriteLine($"{indent}* {tree.Value}");
            indent += "| ";

            for (int i = 0; i < tree.children.Count; i++)
            {
                PrettyPrintTree(tree.children[i], indent);
            }
        }
    }
}
