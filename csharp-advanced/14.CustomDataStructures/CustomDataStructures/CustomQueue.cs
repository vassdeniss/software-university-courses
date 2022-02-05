using System;

namespace CustomDataStructures
{
    public class CustomQueue<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private const int FIRST_IDX = 0;
        private T[] innerArray;

        public CustomQueue()
        {
            Count = 0;
            innerArray = new T[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (innerArray.Length == Count) Resize();
            innerArray[Count++] = element;
        }

        public T Dequeue()
        {
            if (innerArray.Length == 0) throw new InvalidOperationException("Stack is empty");

            Count--;
            if (Count <= innerArray.Length / 4) Shrink();

            T first = innerArray[FIRST_IDX];
            innerArray[FIRST_IDX] = default;
            for (int i = 1; i < innerArray.Length; i++)
            {
                innerArray[i - 1] = innerArray[i];
            }

            return first;
        }

        public T Peek()
        {
            if (innerArray.Length == 0) throw new InvalidOperationException("Stack is empty");

            return innerArray[FIRST_IDX];
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

        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = innerArray[i];
            }

            return array;
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

        private void Shrink()
        {
            T[] newArray = new T[innerArray.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = innerArray[i];
            }

            innerArray = newArray;
        }

        private void Resize()
        {
            T[] copy = new T[innerArray.Length * 2];
            innerArray.CopyTo(copy, 0);
            innerArray = copy;
        }
    }
}
