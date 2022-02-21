namespace E03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IAbstractList<T>
    {
        private enum Index
        {
            CHECK_CAPACITY,
            CHECK_IN_BOUNDS
        }

        private const int DefaultCapacity = 4;
        private T[] items;

        public ReversedList() : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (!Validate(capacity, Index.CHECK_CAPACITY))
                throw new ArgumentOutOfRangeException(nameof(capacity));

            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (!Validate(index, Index.CHECK_IN_BOUNDS))
                {
                    throw new IndexOutOfRangeException("Invalid Index");
                }

                return items[Count - 1 - index];
            }
            set
            {
                if (!Validate(index, Index.CHECK_IN_BOUNDS))
                {
                    throw new IndexOutOfRangeException("Invalid Index");
                }

                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length) Grow();

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[Count - 1 - i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (!Validate(index, Index.CHECK_IN_BOUNDS))
            {
                throw new IndexOutOfRangeException("Invalid Index");
            }

            if (Count == items.Length) Grow();

            index = Count - index;

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            index = Count - 1 - index;

            if (!Validate(index, Index.CHECK_IN_BOUNDS))
            {
                throw new IndexOutOfRangeException("Invalid Index");
            }

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
            Count--;

            if (Count <= items.Length / 4) Shrink();
        }
            
        public void ForEach(Action<T> callback)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                callback(items[i]);
            }
        }

        public void Clear()
        {
            Count = 0;
            items = new T[DefaultCapacity];
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            Array.Copy(items, arr, Count);
            return arr.Reverse().ToArray();
        }

        private void Grow()
        {
            T[] copy = new T[items.Length * 2];
            Array.Copy(items, copy, items.Length);
            items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[items.Length / 2];
            Array.Copy(items, copy, Count);
            items = copy;
        }

        private bool Validate(int n, Index enumValue)
        {
            return enumValue switch
            {
                Index.CHECK_CAPACITY => n > 0,
                Index.CHECK_IN_BOUNDS => n >= 0 && n < Count,
                _ => false,
            };
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
