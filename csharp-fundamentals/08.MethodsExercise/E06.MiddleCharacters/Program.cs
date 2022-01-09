using System;

namespace E06.MiddleCharacters
{
    class Program
    {
        static void MiddleCharacter(string s)
        {
            if (s.Length % 2 == 0)
            {
                int middle = s.Length / 2;
                Console.WriteLine(s[middle - 1].ToString()
                    + s[middle].ToString());
            }
            else
            {
                Console.WriteLine(s[s.Length / 2]);
            }
        }

        static void Main(string[] args)
        {
            MiddleCharacter(Console.ReadLine());
        }
    }
}
