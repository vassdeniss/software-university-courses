using System;

namespace E03.CharactersInRange
{
    class Program
    {
        static void CharRange(char a, char b)
        {
            int chOne = Math.Min(a, b);
            int chTwo = Math.Max(a, b);

            for (int i = chOne + 1; i < chTwo; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }

        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            CharRange(firstChar, secondChar);
        }
    }
}
