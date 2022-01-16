using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.MaximumMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int querieQty = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < querieQty; i++)
            {
                string[] querie = Console.ReadLine().Split();

                string command = querie[0];
                if (command == "1")
                {
                    stack.Push(int.Parse(querie[1]));
                }
                else if (command == "2")
                {
                    stack.Pop();
                }
                else if (command == "3")
                {
                    if (stack.Count > 0) Console.WriteLine(stack.Max());
                }
                else
                {
                    if (stack.Count > 0) Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
