using System;
using System.Collections;
using System.Collections.Generic;

namespace E03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> collection;

        public CustomStack()
        {
            Count = 0;
            collection = new List<T>();
        }

        public int Count { get; private set; }

        public void Push(T element) => collection.Add(element);

        public T Pop()
        {
            if (collection.Count == 0) throw new InvalidOperationException("No elements");

            T el = collection[^1];
            collection.RemoveAt(collection.Count - 1);

            return el;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
