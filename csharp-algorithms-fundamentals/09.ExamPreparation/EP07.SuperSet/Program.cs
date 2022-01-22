using System;

namespace EP07.SuperSet
{
    internal class Program
    {
        private static string[] Input;

        static void Main(string[] args)
        {
            Input = Console.ReadLine().Split(", ");

            Console.WriteLine(string.Empty);
            for (int i = 1; i <= Input.Length; i++)
            {
                string[] combinations = new string[i];
                Combinate(combinations, 0, 0);
            }
        }

        private static void Combinate(string[] combinations, int index, int start)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < Input.Length; i++)
            {
                combinations[index] = Input[i];
                Combinate(combinations, index + 1, i + 1);
            }
        }
    }
}
