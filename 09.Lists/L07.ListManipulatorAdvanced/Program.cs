using System;
using System.Collections.Generic;
using System.Linq;

namespace L07.ListManipulatorAdvanced
{
    class Program
    {
        static void PrintEven(List<int> list)
        {
            foreach (int i in list)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

        static void PrintOdd(List<int> list)
        {
            foreach (int i in list)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

        static int GetSum(List<int> list)
        {
            int sum = 0;
            foreach (int i in list) sum += i;
            return sum;
        }

        static void Filter(List<int> list, string condition, int number)
        {
            foreach (int i in list)
            {
                switch (condition)
                {
                    case "<":
                        if (i < number)
                            Console.Write($"{i} ");
                        break;
                    case ">":
                        if (i > number)
                            Console.Write($"{i} ");
                        break;
                    case "<=":
                        if (i <= number)
                            Console.Write($"{i} ");
                        break;
                    case ">=":
                        if (i >= number)
                            Console.Write($"{i} ");
                        break;
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();
            bool isChanged = false;
            

            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    numbers.Add(int.Parse(commands[1]));
                    isChanged = true;
                }
                else if (commands[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commands[1]));
                    isChanged = true;
                }
                else if (commands[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commands[1]));
                    isChanged = true;
                }
                else if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                    isChanged = true;
                }
                else if (commands[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(commands[1])))
                        Console.WriteLine("Yes");
                    else
                        Console.WriteLine("No such number");
                }
                else if (commands[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (commands[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (commands[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(numbers));
                }
                else if (commands[0] == "Filter")
                {
                    Filter(numbers, commands[1], int.Parse(commands[2]));
                }

                commands = Console.ReadLine().Split();
            }

            if (isChanged)
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
