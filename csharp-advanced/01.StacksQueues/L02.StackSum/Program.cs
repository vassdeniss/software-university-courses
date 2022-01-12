using System;
using System.Collections.Generic;
using System.Linq;

namespace L02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> numStack = new Stack<int>(nums);
            
            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] cmd = input.Split();
                if (cmd[0].ToLower() == "add")
                {
                    numStack.Push(int.Parse(cmd[1]));
                    numStack.Push(int.Parse(cmd[2]));
                }
                else if (cmd[0].ToLower() == "remove")
                {
                    int qty = int.Parse(cmd[1]);
                    if (qty <= numStack.Count)
                    {
                        for (int i = 0; i < qty; i++)
                        {
                            numStack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numStack.Sum()}");
        }
    }
}
