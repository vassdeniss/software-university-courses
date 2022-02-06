using System;
using System.Collections.Generic;

namespace E06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double comparator = double.Parse(Console.ReadLine());
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
