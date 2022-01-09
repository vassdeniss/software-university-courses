using System;
using System.Text;

namespace L02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();

            foreach (string s in input)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    sb.Append(s);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
