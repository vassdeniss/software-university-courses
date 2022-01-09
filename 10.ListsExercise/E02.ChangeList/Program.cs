using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "Delete")
                {
                    numbers.RemoveAll(n => n == int.Parse(commands[1]));
                }
                else if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
