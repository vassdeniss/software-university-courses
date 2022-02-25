namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesByKey;

        public TreeFactory()
        {
            nodesByKey = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (string s in input)
            {
                int[] keys = s.Split().Select(int.Parse).ToArray();

                int parent = keys[0];
                int child = keys[1];

                AddEdge(parent, child);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                nodesByKey.Add(key, new Tree<int>(key));
            }

            return nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = CreateNodeByKey(parent);
            Tree<int> childNode = CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public Tree<int> GetRoot()
        {
            foreach (KeyValuePair<int, Tree<int>> kvp in nodesByKey)
            {
                if (kvp.Value.Parent is null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
