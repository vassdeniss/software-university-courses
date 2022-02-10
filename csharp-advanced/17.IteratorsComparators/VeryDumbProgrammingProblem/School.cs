using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// "School" list that just implements IList<T> 
/// and only implements indexing and adding to the inner array
/// and of course the most important part - the enumerator which skips over 2 teachers
/// </summary>

namespace VeryDumbProgrammingProblem
{
    public class School<T> : IList<T>
    {
        private T[] arr;
        private int size = 2;

        public School()
        {
            arr = new T[size];
            Count = 0;
        }

        public T this[int index] { get => arr[index]; set => arr[index] = value; }

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (arr.Length == Count) Resize();
            arr[Count++] = item;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                yield return arr[i];
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            T[] copy = new T[arr.Length * 2];
            arr.CopyTo(copy, 0);
            arr = copy;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
