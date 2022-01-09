using System;

namespace L04.VariationRepetition
{
    internal class Program
    {
        private static int K;
        private static string[] Input;
        private static string[] Variations;

        static void Main(string[] args)
        {
            Input = Console.ReadLine().Split();
            K = int.Parse(Console.ReadLine());
            Variations = new string[K];

            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= Variations.Length)
            {
                Console.WriteLine(string.Join(" ", Variations));
                return;
            }

            for (int i = 0; i < Input.Length; i++)
            {
                Variations[index] = Input[i];
                Variate(index + 1);
            }
        }
    }
}
