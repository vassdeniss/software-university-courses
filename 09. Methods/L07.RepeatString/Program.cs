using System;

namespace L07.RepeatString
{
    class Program
    {
        static string Repeat(string s, int n)
        {
            string result = String.Empty;

            for (int i = 0; i < n; i++)
            {
                result += s;
            }

            return result;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());

            Console.WriteLine(Repeat(input, repeat));
        }
    }
}
