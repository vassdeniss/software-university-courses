using System;
using System.Collections.Generic;

namespace L01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverse = new Stack<char>();
            foreach (char c in input) reverse.Push(c);

            Console.WriteLine(string.Join("", reverse));
        }
    }
}
