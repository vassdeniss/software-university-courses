using System;

namespace E05.CircularQueue
{
    public class CircularQueue<T>
    {
        private const int InitialCapacity = 8;
        
        private T[] elements;

        public int Count { get; private set; }
        public int Capacity => elements.Length;
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }

        public CircularQueue(int capacity = InitialCapacity)
        {
            elements = new T[capacity];
            StartIndex = 0;
            EndIndex = 0;
        }

        public void Enqueue(T element)
        {
            if (Count >= elements.Length) Grow();
            elements[EndIndex] = element;
            EndIndex = (EndIndex + 1) % elements.Length;
            Count++;
        }

        private void Grow()
        {
            T[] newElements = new T[2 * elements.Length];
            CopyAllElementsTo(newElements);
            elements = newElements;
            StartIndex = 0;
            EndIndex = Count;
        }

        private void CopyAllElementsTo(T[] resultArr)
        {
            int sourceIndex = StartIndex;
            for (int destIndex = 0; destIndex < Count; destIndex++)
            {
                resultArr[destIndex] = elements[sourceIndex];
                sourceIndex = (sourceIndex + 1) % elements.Length;
            }
        }

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("The queue is empty!");

            T result = elements[StartIndex];
            StartIndex = (StartIndex + 1) % elements.Length;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("The queue is empty!");

            T result = elements[StartIndex];
            return result;
        }

        public T[] ToArray()
        {
            T[] resultArray = new T[Count];
            CopyAllElementsTo(resultArray);
            return resultArray;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", ToArray())}]";
        }
    }
}
