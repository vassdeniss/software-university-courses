namespace E03.MinHeap
{
    using System;

    public interface IAbstractHeap<T> where T : IComparable<T>
    {
        int Size { get; }

        void Add(T element);

        T Peek();

        T ExtractMin();
    }
}
