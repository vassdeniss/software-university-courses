namespace L02.BinarySearchTree
{
    using System;

    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        void Insert(T element);

        bool Contains(T element);

        void EachInOrder(Action<T> action);

        IBinarySearchTree<T> Search(T element);
    }
}
