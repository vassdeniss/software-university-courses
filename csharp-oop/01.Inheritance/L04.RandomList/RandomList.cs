using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int idx = rnd.Next(0, Count);
            string element = this[idx];
            RemoveAt(idx);
            return element;
        }
    }
}
