using System;
using System.Collections.Generic;

namespace E03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        protected Dictionary<T, int> indices;
        protected List<T> heap;

        public MinHeap()
        {
            heap = new List<T>();
            indices = new Dictionary<T, int>();
        }

        public int Size => heap.Count;

        public void Add(T element)
        {
            heap.Add(element);
            indices.Add(element, heap.Count - 1);
            HeapifyUp(heap.Count - 1);
        }

        protected void HeapifyUp(int idx)
        {
            int parentIdx = (idx - 1) / 2;
            while (idx > 0 && heap[idx].CompareTo(heap[parentIdx]) < 0)
            {
                Swap(idx, parentIdx);
                idx = parentIdx;
                parentIdx = (idx - 1) / 2;
            }
        }

        public T ExtractMin()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = heap[0];

            Swap(0, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            indices.Remove(element);
            HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int idx)
        {   
            int smallerChild = GetSmallerChild(idx);
            while (smallerChild >= 0 && smallerChild < heap.Count && heap[smallerChild].CompareTo(heap[idx]) < 0)
            {
                Swap(smallerChild, idx);
                idx = smallerChild;
                smallerChild = GetSmallerChild(idx);
            }
        }

        private void Swap(int first, int second)
        {
            (heap[first], heap[second]) = (heap[second], heap[first]);
            indices[heap[first]] = first;
            indices[heap[second]] = second;
        }

        private int GetSmallerChild(int idx)
        {
            int first = idx * 2 + 1;
            int second = idx * 2 + 2;

            if (second < heap.Count)
            {
                return heap[first].CompareTo(heap[second]) < 0 ? first : second;
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
