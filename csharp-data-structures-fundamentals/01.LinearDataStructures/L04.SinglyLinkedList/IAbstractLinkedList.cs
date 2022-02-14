namespace L04.SinglyLinkedList
{
    using System.Collections.Generic;

    public interface IAbstractLinkedList<T> : IEnumerable<T>
    {
        int Count { get; }

        void AddFirst(T item);

        void AddLast(T item);

        T GetFirst();

        T GetLast();

        T RemoveFirst();

        T RemoveLast();
    }
}
