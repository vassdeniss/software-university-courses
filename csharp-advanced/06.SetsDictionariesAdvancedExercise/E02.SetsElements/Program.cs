using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.SetsElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            int[] input = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int n = input[0];   
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setTwo.Add(num);
            }

            setOne.IntersectWith(setTwo);
            Console.WriteLine(string.Join(" ", setOne));
        }
    }
}
