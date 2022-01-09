using System;

namespace E02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Console.WriteLine(MultiplyCharacters(input[0], input[1]));
        }

        static int MultiplyCharacters(string s, string s1)
        {
            int sum = 0;

            string smallerString = s.Length > s1.Length ? s1 : s;
            string biggerString = s.Length > s1.Length ? s : s1;
            for (int i = 0; i < smallerString.Length; i++)
                sum += s[i] * s1[i];

            for (int i = smallerString.Length; i < biggerString.Length; i++)
                sum += biggerString[i];

            return sum;
        }
    }
}
