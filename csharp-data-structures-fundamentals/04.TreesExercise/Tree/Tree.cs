namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (Tree<T> child in children)
            {
                AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            AsString(this, string.Empty, sb);
            return sb.ToString().TrimEnd();
        }

        private void AsString(Tree<T> tree, string indent, StringBuilder sb)
        {
            sb.AppendLine($"{indent}{tree.Key}");
            indent += "  ";

            for (int i = 0; i < tree.children.Count; i++)
            {
                AsString(tree.children[i], indent, sb);
            }
        }

        public List<T> GetLeafKeys()
        {
            List<T> result = new List<T>();
            DFS(this, result);
            return result;
        }

        private IEnumerable<Tree<T>> GetLeafNodes()
        {
            List<Tree<T>> result = new List<Tree<T>>();
            BFS(result);
            return result;
        }

        // nice typo softuni ;d
        public Tree<T> GetDeepestLeftomostNode()
        {
            IEnumerable<Tree<T>> leaves = GetLeafNodes();

            int deepestDepth = 0;
            Tree<T> deepestNode = null;
            foreach (Tree<T> node in leaves)
            {
                int currDepth = GetNodeDepth(node);
                if (currDepth > deepestDepth)
                {
                    deepestDepth = currDepth;
                    deepestNode = node;
                }
            }

            return deepestNode;
        }

        private int GetNodeDepth(Tree<T> node)
        {
            int depth = 0;

            Tree<T> curr = node;
            while (curr.Parent != null)
            {
                depth++;
                curr = curr.Parent;
            }

            return depth;
        }

        private void DFS(Tree<T> tree, List<T> result)
        {
            foreach (Tree<T> child in tree.children)
            {
                DFS(child, result);
            }

            if (!tree.children.Any())
            {
                result.Add(tree.Key);
            }
        }

        private void BFS(List<Tree<T>> result)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();

                if (!subtree.children.Any())
                {
                    result.Add(subtree);
                }

                foreach (Tree<T> child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
        }
        
        public List<T> GetLongestPath()
        {
            List<T> longestPath = new List<T>();
            // Nice typo softuni ;d
            Tree<T> deepestNode = GetDeepestLeftomostNode();

            longestPath.Add(deepestNode.Key);
            while (deepestNode.Parent != null)
            {
                deepestNode = deepestNode.Parent;
                longestPath.Add(deepestNode.Key);
            }

            longestPath.Reverse();
            return longestPath;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();
            OrdersDfsMiddle(result, this);
            return result.OrderBy(leaf => leaf).ToList();
        }

        private void OrdersDfsMiddle(List<T> result, Tree<T> subtree)
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(subtree);

            while (stack.Count > 0)
            {
                Tree<T> curr = stack.Pop();

                if (curr.Parent != null && curr.Children.Count != 0)
                {
                    result.Add(curr.Key);
                }

                foreach (Tree<T> child in curr.Children)
                {
                    stack.Push(child);
                }
            }
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> result = new List<List<T>>();

            Stack<T> path = new Stack<T>();
            int total = int.Parse(Key.ToString());
            path.Push(Key);

            DFS(this, sum, ref total, path, result);

            return result;
        }

        private void DFS(Tree<T> tree,
                    int sum,
                    ref int total,
                    Stack<T> path,
                    List<List<T>> result)
        {
            if (tree.Children.Count == 0)
            {
                if (total == sum)
                {
                    List<T> list = new List<T>();
                    foreach (T element in path) list.Add(element);
                    list.Reverse();
                    result.Add(list);
                }

                return;
            }

            foreach (Tree<T> child in tree.Children)
            {
                total += int.Parse(child.Key.ToString());
                path.Push(child.Key);

                DFS(child, sum, ref total, path, result);

                path.Pop();
                total -= int.Parse(child.Key.ToString());
            }
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> subtrees = new List<Tree<T>>();
            SubtreesSum(this, sum, subtrees);
            return subtrees;
        }

        private int SubtreesSum(Tree<T> tree, int sum, List<Tree<T>> subtrees)
        {
            int currSum = int.Parse(tree.Key.ToString());
            foreach (Tree<T> child in tree.Children)
            {
                currSum += SubtreesSum(child, sum, subtrees);
            }

            if (currSum == sum) subtrees.Add(tree);
            return currSum;
        }
    }
}
