using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.Train
{
    class Program
    {
        static void AddPassengers(List<int> list, int max, int people)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] + people <= max)
                {
                    list[i] += people;
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> wagonList = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            int maxPerWagon = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    wagonList.Add(int.Parse(commands[1]));
                }
                else
                {
                    AddPassengers(wagonList, maxPerWagon, int.Parse(commands[0]));
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", wagonList));
        }
    }
}
