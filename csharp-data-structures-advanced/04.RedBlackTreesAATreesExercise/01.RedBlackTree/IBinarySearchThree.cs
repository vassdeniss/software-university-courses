using System;
using System.Collections.Generic;

namespace _01.RedBlackTree
{
    public interface IBinarySearchTree<T> where T: IComparable
    {
        int Count { get; }

        void Insert(T element);

        bool Contains(T element);

        void EachInOrder(Action<T> action);

        IBinarySearchTree<T> Search(T element);

        void Delete(T element);

        void DeleteMin();

        void DeleteMax();

        int Rank(T element);

        T Select(int rank);

        T Ceiling(T element);

        T Floor(T element);

        IEnumerable<T> Range(T startRange, T endRange);
    }
}
