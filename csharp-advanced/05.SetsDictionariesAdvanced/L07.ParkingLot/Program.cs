using System;
using System.Collections;
using System.Collections.Generic;

namespace L07.ParkingLot
{
    class OrangeSet<T> : ICollection<T>
    {
        private IDictionary<T, LinkedListNode<T>> dic;
        private LinkedList<T> lList;

        public OrangeSet()
        {
            dic = new Dictionary<T, LinkedListNode<T>>();
            lList = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return dic.Count;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return dic.IsReadOnly;
            }
        }

        public bool Remove(T item)
        {
            if (dic.ContainsKey(item))
            {
                lList.Remove(dic[item]);
                dic.Remove(item);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return lList.GetEnumerator();
        }

        public bool Contains(T item)
        {
            return dic.ContainsKey(item);
        }

        public void Add(T item)
        {
            if (!dic.ContainsKey(item))
            {
                LinkedListNode<T> node = lList.AddLast(item);
                dic.Add(item, node);
            }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        public void Clear()
        {
            dic.Clear();
            lList.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lList.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OrangeSet<string> lot = new OrangeSet<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(", ");
                if (data[0] == "IN") lot.Add(data[1]);
                else lot.Remove(data[1]);

                input = Console.ReadLine();
            }

            if (lot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string carNum in lot)
                {
                    Console.WriteLine(carNum);
                }
            }
        }
    }
}
