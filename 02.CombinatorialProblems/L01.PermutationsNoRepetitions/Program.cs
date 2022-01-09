using System;

namespace L01.PermutationsNoRepetitions
{
    internal class Program
    {
        private static string[] Input;
        private static string[] Permutations;
        private static bool[] IsUsed;

        static void Main(string[] args)
        {
            Input = Console.ReadLine().Split();
            Permutations = new string[Input.Length];
            IsUsed = new bool[Input.Length];

            Permutate(0);
        }

        private static void Permutate(int index)
        {
            if (index >= Input.Length)
            {
                Console.WriteLine(string.Join(" ", Permutations));
                return;
            }

            for (int i = 0; i < Input.Length; i++)
            {
                if (!IsUsed[i])
                {
                    IsUsed[i] = true;
                    Permutations[index] = Input[i];
                    Permutate(index + 1);
                    IsUsed[i] = false;
                }
            }
        }
    }
}
