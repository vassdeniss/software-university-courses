using System;
using System.Linq;

namespace ME01.EncryptSortPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int[] output = new int[num];

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;

                foreach (char c in input)
                {
                    if (vowels.Contains(c))
                    {
                        sum += c * input.Length;
                    }
                    else
                    {
                        sum += c / input.Length;
                    }
                }

                output[i] = sum;
            }

            Array.Sort(output);

            foreach (int i in output)
            {
                Console.WriteLine(i);
            }
        }
    }
}
