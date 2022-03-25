using System;

namespace Database
{
    public class Database
    {
        private int[] data;
        private int count;

        public Database(params int[] data)
        {
            this.data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }

            count = data.Length;
        }

        public int Count => count;

        public void Add(int element)
        {
            if (count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            data[count] = element;
            count++;
        }

        public void Remove()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            count--;
            data[count] = 0;
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                coppyArray[i] = data[i];
            }

            return coppyArray;
        }
    }
}
