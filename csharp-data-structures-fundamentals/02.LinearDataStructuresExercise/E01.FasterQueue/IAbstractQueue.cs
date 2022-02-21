namespace E01.FasterQueue
{
    using System.Collections.Generic;

    public interface IAbstractQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        void Enqueue(T item);

        T Dequeue();

        T Peek();

        T[] ToArray();

        bool Contains(T item);
    }
}
