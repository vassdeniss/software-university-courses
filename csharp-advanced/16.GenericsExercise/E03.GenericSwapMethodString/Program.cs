using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.GenericSwapMethodString
{
    internal class Program
    {
        private static List<Box<string>> List;

        static void Main(string[] args)
        {
            List = new List<Box<string>>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                List.Add(new Box<string>(Console.ReadLine()));
            }

            int[] swapIndices = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            Swap(swapIndices[0], swapIndices[1]);
            List.ForEach(Console.WriteLine);
        }

        private static void Swap(int first, int second)
        {
            (List[first], List[second]) = (List[second], List[first]);
        }
    }
}
