using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTable<TKey, TValue> 
        : IEnumerable<KeyValue<TKey, TValue>>
    {
        public const int InitialCapacity = 16;
        public const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable(int capacity = InitialCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public void Add(TKey key, TValue value)
        {
            this.Grow();

            int slotIndex = this.FindIndex(key);
            if (this.slots[slotIndex] == null)
            {
                this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (KeyValue<TKey, TValue> element in this.slots[slotIndex])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException($"Key already exists: {key}");
                }
            }

            KeyValue<TKey, TValue> newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotIndex].AddLast(newElement);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            this.Grow();

            int slotIndex = this.FindIndex(key);
            if (this.slots[slotIndex] == null)
            {
                this.slots[slotIndex] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (KeyValue<TKey, TValue> element in this.slots[slotIndex])
            {
                if (element.Key.Equals(key))
                {
                    element.Value = value;
                    return false;
                }
            }

            KeyValue<TKey, TValue> newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotIndex].AddLast(newElement);
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            KeyValue<TKey, TValue> element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException();
            }
            
            return element.Value;
        }

        public TValue this[TKey key]
        {
            get => this.Get(key);
            set => this.AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            KeyValue<TKey, TValue> element = this.Find(key);
            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = this.FindIndex(key);
            
            LinkedList<KeyValue<TKey, TValue>> elements = this.slots[index];
            if (elements != null)
            {
                foreach (KeyValue<TKey, TValue> element in elements)
                {
                    if (element.Key.Equals(key))
                    {
                        return element;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return this.Find(key) != null;
        }

        public bool Remove(TKey key)
        {
            int index = this.FindIndex(key);
            LinkedList<KeyValue<TKey, TValue>> elements = this.slots[index];
            if (elements != null)
            {
                LinkedListNode<KeyValue<TKey, TValue>> current = elements.First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        elements.Remove(current);
                        this.Count--;
                        return true;
                    }

                    current = current.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[InitialCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys
            => this.Select(element => element.Key);

        public IEnumerable<TValue> Values
            => this.Select(element => element.Value);


        private void Grow()
        {
            if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
            {
                HashTable<TKey, TValue> newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
                foreach (KeyValue<TKey, TValue> element in this)
                {
                    newHashTable.Add(element.Key, element.Value);
                }

                this.slots = newHashTable.slots;
                this.Count = newHashTable.Count;
            }
        }

        private int FindIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.slots.Length;
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (LinkedList<KeyValue<TKey, TValue>> elements in this.slots)
            {
                if (elements == null) continue;
                foreach (KeyValue<TKey, TValue> element in elements)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
