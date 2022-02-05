using System;

namespace CustomDataStructures
{
    public class CustomStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] innerArray;

        public CustomStack()
        {
            Count = 0;
            innerArray = new T[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (innerArray.Length == Count) Resize();
            innerArray[Count++] = element;
        }

        public T Pop()
        {
            if (innerArray.Length == 0) throw new InvalidOperationException("Stack is empty");

            Count--;
            if (Count <= innerArray.Length / 4) Shrink();

            return innerArray[Count - 1];
        }

        public T Peek()
        {
            if (innerArray.Length == 0) throw new InvalidOperationException("Stack is empty");
            
            return innerArray[Count - 1];
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
