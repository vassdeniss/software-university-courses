using System;
using System.Linq;

namespace E03.Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] array = input.Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (array[0] == "Push")
                {
                    foreach (string element in array.Skip(1))
                    {
                        stack.Push(int.Parse(element));
                    }
                }
                else if (array[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int n in stack)
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
