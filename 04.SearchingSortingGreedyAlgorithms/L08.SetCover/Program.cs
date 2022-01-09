using System;
using System.Collections.Generic;
using System.Linq;

namespace L08.SetCover
{
    internal class Program
    {
        private static List<int> Universe;
        private static List<int[]> Sets;

        static void Main(string[] args)
        {
            Universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            Sets = new List<int[]>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
                Sets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            List<int[]> selectedSets = SelectSets();
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (int[] set in selectedSets) Console.WriteLine(string.Join(", ", set));
        }

        private static List<int[]> SelectSets()
        {
            List<int[]> list = new List<int[]>();
            while (Universe.Count > 0)
            {
                int[] currSet = Sets.OrderByDescending(x => x.Count(c => Universe.Contains(c))).First();
                foreach (int n in currSet) Universe.Remove(n);
                Sets.Remove(currSet);
                list.Add(currSet);
            }

            return list;
        }
    }
}
