using System;
using System.Collections.Generic;

namespace E05.ReverseNumbersWithStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(nums);
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
