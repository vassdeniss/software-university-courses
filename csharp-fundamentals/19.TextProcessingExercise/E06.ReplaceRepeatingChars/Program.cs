using System;

namespace E06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char nextChar;

                if (i + 1 >= input.Length) nextChar = input[i - 1];
                else nextChar = input[i + 1];

                int count = 1;
                while (nextChar == input[i])
                {
                    count++;
                    if (i + count >= input.Length) break;
                    else nextChar = input[i + count];
                }

                if (count > 1) input = input.Remove(i, count - 1);
            }

            Console.WriteLine(input);
        }
    }
}
