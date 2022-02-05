using System;

namespace CustomDataStructures
{
    public class CustomList<T>
    {
        private const int INITIAL_CAPACITY = 2;
        private T[] innerArray;

        public CustomList()
        {
            innerArray = new T[INITIAL_CAPACITY];
            Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= Count) throw new ArgumentOutOfRangeException();
                return innerArray[index];
            }
            set
            {
                if (index >= Count) throw new ArgumentOutOfRangeException();
                innerArray[index] = value;
            }
        }

        public void Add(T element)
        {
            if (innerArray.Length == Count) Resize();
            innerArray[Count++] = element;
        }

        public T RemoveAt(int idx)
        {
            if (idx >= Count) throw new ArgumentOutOfRangeException();

            T element = innerArray[idx];

            innerArray[idx] = default;
            ShiftLeft(idx);

            Count--;
            if (Count <= innerArray.Length / 4) Shrink();

            return element;
        }

        public void Insert(int idx, T element)
        {
            if (idx > Count) throw new ArgumentOutOfRangeException();
            if (Count >= innerArray.Length) Resize();

            ShiftRight(idx);
            innerArray[idx] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (innerArray[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            Count = 0;
            innerArray = new T[INITIAL_CAPACITY];
        }

        public void ForEach(Action<T> callback)
        {
            for (int i = 0; i < Count; i++)
            {
                callback(innerArray[i]);
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = innerArray[i];
            }

            return array;
        }

        private void Resize()
        {
            T[] copy = new T[innerArray.Length * 2];
            innerArray.CopyTo(copy, 0);
            innerArray = copy;
        }

        private void ShiftRight(int idx)
        {
            for (int i = Count; i > idx; i--)
            {
                innerArray[i] = innerArray[i - 1];
            }
        }

        private void ShiftLeft(int idx)
        {
            for (int i = idx; i < Count - 1; i++)
            {
                innerArray[i] = innerArray[i + 1];
            }
        }

        public void Swap(int first, int second)
        {
            (innerArray[first], innerArray[second]) = (innerArray[second], innerArray[first]);
        }

        private void Shrink()
        {
            T[] newArray = new T[innerArray.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = innerArray[i];
            }

            innerArray = newArray;
        }
    }
}
