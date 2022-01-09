using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM02.Numbers
{
    class Program
    {
        static void Replace(List<int> list, int find, int replace)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == find)
                {
                    list[i] = replace;
                    break;
                }
            }
        }

        static void Collapse(List<int> list, int condition)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < condition)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Finish")
            {
                if (cmd[0] == "Add")
                {
                    numbers.Add(int.Parse(cmd[1]));
                }
                else if (cmd[0] == "Remove")
                {
                    numbers.Remove(int.Parse(cmd[1]));
                }
                else if (cmd[0] == "Replace")
                {
                    Replace(numbers, int.Parse(cmd[1]), int.Parse(cmd[2]));
                }
                else if (cmd[0] == "Collapse")
                {
                    Collapse(numbers, int.Parse(cmd[1]));
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
