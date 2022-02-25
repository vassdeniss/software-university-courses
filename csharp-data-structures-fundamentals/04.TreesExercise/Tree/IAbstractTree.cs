namespace Tree
{
    using System.Collections.Generic;

    interface IAbstractTree<T>
    {
        T Key { get; }

        Tree<T> Parent { get; }

        IReadOnlyCollection<Tree<T>> Children { get; }

        void AddParent(Tree<T> parent);

        void AddChild(Tree<T> child);

        string GetAsString();

        List<T> GetLeafKeys();

        List<T> GetMiddleKeys();

        // Nice typo softuni ;d
        Tree<T> GetDeepestLeftomostNode();

        List<T> GetLongestPath();

        List<List<T>> PathsWithGivenSum(int sum);

        List<Tree<T>> SubTreesWithGivenSum(int sum);
    }
}
