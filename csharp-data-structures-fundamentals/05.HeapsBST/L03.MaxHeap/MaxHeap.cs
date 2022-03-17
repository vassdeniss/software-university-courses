namespace L03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private readonly List<T> heap;

        public MaxHeap() => heap = new List<T>();

        public int Size => heap.Count;

        public void Add(T element)
        {
            heap.Add(element);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int idx)
        {
            int parentIdx = (idx - 1) / 2;
            while (idx > 0 && heap[idx].CompareTo(heap[parentIdx]) > 0)
            {
                (heap[idx], heap[parentIdx]) = (heap[parentIdx], heap[idx]);
                idx = parentIdx;
                parentIdx = (idx - 1) / 2;
            }
        }

        public T ExtractMax()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = heap[0];

            (heap[0], heap[^1]) = (heap[^1], heap[0]);
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int idx)
        {
            int biggerChild = GetBiggerChild(idx);
            while (biggerChild >= 0 && biggerChild < heap.Count && heap[biggerChild].CompareTo(heap[idx]) > 0)
            {
                (heap[biggerChild], heap[idx]) = (heap[idx], heap[biggerChild]);
                idx = biggerChild;
                biggerChild = GetBiggerChild(idx);
            }
        }

        private int GetBiggerChild(int idx)
        {
            int first = idx * 2 + 1;
            int second = idx * 2 + 2;

            if (second < heap.Count)
            {
                return heap[first].CompareTo(heap[second]) > 0 ? first : second;
            }
            else if (first < heap.Count)
            {
                return first;
            }
            else return -1;
        }

        public T Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }
    }
}
