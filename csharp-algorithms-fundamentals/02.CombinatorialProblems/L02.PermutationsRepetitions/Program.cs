using System;
using System.Collections.Generic;

namespace L02.PermutationsRepetitions
{
    internal class Program
    {
        private static string[] Permutations;

        static void Main(string[] args)
        {
            Permutations = Console.ReadLine().Split();
            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index >= Permutations.Length)
            {
                Console.WriteLine(string.Join(" ", Permutations));
                return;
            }

            Permutate(index + 1);
            HashSet<string> used = new HashSet<string>() { Permutations[index] };

            for (int i = index + 1; i < Permutations.Length; i++)
            {
                if (!used.Contains(Permutations[i]))
                {
                    Swap(index, i);
                    Permutate(index + 1);
                    Swap(index, i);
                    used.Add(Permutations[i]);
                }
            }
        }

        private static void Swap(int first, int second) =>
            (Permutations[first], Permutations[second]) = (Permutations[second], Permutations[first]);
    }
}
