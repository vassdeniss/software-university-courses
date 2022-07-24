using System;

namespace _01.RedBlackTree
{
    public interface IBinarySearchTree<T> where T: IComparable
    {
        // Basic Tree Operations
        void Insert(T element);

        bool Contains(T element);

        void EachInOrder(Action<T> action);

        // Binary Search Tree Operations
        int Count();
    }
}
