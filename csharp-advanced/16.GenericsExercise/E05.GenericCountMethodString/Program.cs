using System;
using System.Collections.Generic;

namespace E05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                list.Add(Console.ReadLine());
            }

            string comparator = Console.ReadLine();
            Console.WriteLine(Comparer(list, comparator));
        }

        private static int Comparer<T>(List<T> list, T comparator)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (T generic in list)
            {
                if (generic.CompareTo(comparator) > 0) count++;
            }

            return count;
        }
    }
}
