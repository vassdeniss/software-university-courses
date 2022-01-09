using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.ListOperations
{
    class Program
    {
        static void ShiftLeft(List<int> list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list.Add(list[0]);
                list.RemoveAt(0);
            }
        }

        static void ShiftRight(List<int> list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list.Insert(0, list[^1]);
                list.RemoveAt(list.Count - 1);
            }
        }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "End")
            {
                if (commands[0] == "Add")
                {
                    numbers.Add(int.Parse(commands[1]));
                }
                else if (commands[0] == "Insert")
                {
                    int number = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    try
                    {
                        numbers.Insert(index, number);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commands[0] == "Remove")
                {
                    int index = int.Parse(commands[1]);

                    try
                    {
                        numbers.RemoveAt(index);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commands[0] == "Shift")
                {
                    if (commands[1] == "left")
                        ShiftLeft(numbers, int.Parse(commands[2]));
                    else
                        ShiftRight(numbers, int.Parse(commands[2]));
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
