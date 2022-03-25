using System;
using System.Text;

namespace E06.Collection
{
    public class Collection<T>
    {
        private const int InitialCapacity = 16;

        private T[] items;

        public int Capacity => items.Length;
        public int Count { get; private set; }

        public Collection(params T[] items)
        {
            int capacity = Math.Max(2 * items.Length, InitialCapacity);
            this.items = new T[capacity];
            for (int i = 0; i < items.Length; i++) this.items[i] = items[i];
            Count = items.Length;
        }

        public void Add(T item)
        {
            EnsureCapacity();
            items[Count] = item;
            Count++;
        }

        public void AddRange(params T[] items)
        {
            foreach (T item in items) Add(item);
        }

        private void EnsureCapacity()
        {
            if (Count == Capacity)
            {
                T[] oldItems = items;
                items = new T[2 * oldItems.Length];
                for (int i = 0; i < Count; i++) items[i] = oldItems[i];
            }
        }

        public T this[int index]
        {
            get
            {
                CheckRange(index, nameof(index), minValue: 0, maxValue: Count - 1);
                return items[index];
            }
            set
            {
                CheckRange(index, nameof(index), minValue: 0, maxValue: Count - 1);
                items[index] = value;
            }
        }

        public void InsertAt(int index, T item)
        {
            CheckRange(index, nameof(index), minValue: 0, maxValue: Count);
            EnsureCapacity();
            for (int i = Count - 1; i >= index; i--) items[i + 1] = items[i];
            items[index] = item;
            Count++;
        }

        private void CheckRange(int index, string paramName, int minValue, int maxValue)
        {
            if ((index < minValue) || (index > maxValue))
            {
                string errMsg = $"Parameter should be in the range [{minValue}...{maxValue}]";
                throw new ArgumentOutOfRangeException(paramName, index, errMsg);
            }
        }

        public void Exchange(int index1, int index2)
        {
            CheckRange(index1, nameof(index1), minValue: 0, maxValue: Count - 1);
            CheckRange(index2, nameof(index1), minValue: 0, maxValue: Count - 1);
            T oldItem = items[index1];
            items[index1] = items[index2];
            items[index2] = oldItem;
        }

        public T RemoveAt(int index)
        {
            CheckRange(index, nameof(index), minValue: 0, maxValue: Count - 1);
            T removedItem = items[index];
            for (int i = index + 1; i < Count; i++) items[i - 1] = items[i];
            Count--;
            return removedItem;
        }

        public void Clear() => Count = 0;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("[");

            for (int i = 0; i < Count; i++)
            {
                if (i > 0) result.Append(", ");
                result.Append(items[i]);
            }

            result.Append("]");
            return result.ToString();
        }
    }
}
