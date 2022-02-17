namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine()
                .Split(", ").Select(int.Parse).ToList();
            List<int[]> sets = new List<int[]>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
                sets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            List<int[]> selectedSets = ChooseSets(sets, universe);
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (int[] set in selectedSets) Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> list = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] curr = sets.OrderByDescending(x => x.Count(y => universe.Contains(y))).First();
                foreach (int n in curr) universe.Remove(n);
                sets.Remove(curr);
                list.Add(curr);
            }

            return list;
        }
    }
}
