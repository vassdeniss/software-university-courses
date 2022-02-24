namespace Tree
{
    using System.Collections.Generic;

    interface IAbstractTree<T>
    {
        ICollection<T> OrderBfs();

        ICollection<T> OrderDfs();

        void AddChild(T parentKey, Tree<T> child);

        void RemoveNode(T nodeKey);

        void Swap(T firstKey, T secondKey);
    }
}
