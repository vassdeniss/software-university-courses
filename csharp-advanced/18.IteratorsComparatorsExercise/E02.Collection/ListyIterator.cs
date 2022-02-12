using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> list;
        private int idx;

        public ListyIterator(params T[] list)
        {
            this.list = list.ToList();
            idx = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                idx++;
                return true;
            }

            return false;
        }

        public bool HasNext() => idx + 1 < list.Count;

        public void Print()
        {
            if (list.Count == 0) throw new Exception("Invalid Operation!");
            Console.WriteLine(list[idx]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
