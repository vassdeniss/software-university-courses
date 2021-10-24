using System;
using System.Collections.Generic;
using System.Linq;

namespace EXAM03.TheAngryCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine()
                .Split(", ").Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string itemType = Console.ReadLine();

            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();
            for (int i = 0; i < entryPoint; i++)
                leftSide.Add(priceRatings[i]);
            for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                rightSide.Add(priceRatings[i]);

            int leftSum = 0;
            int rightSum = 0;
            int comparator = priceRatings[entryPoint];
            foreach (int n in leftSide)
            {
                if (itemType == "cheap" && n < comparator)
                    leftSum += n;
                else if (itemType == "expensive" && n >= comparator)
                    leftSum += n;
            }
            foreach (int n in rightSide)
            {
                if (itemType == "cheap" && n < comparator)
                    rightSum += n;
                else if (itemType == "expensive" && n >= comparator)
                    rightSum += n;
            }

            if (leftSum >= rightSum)
                Console.WriteLine($"Left - {leftSum}");
            else
                Console.WriteLine($"Right - {rightSum}");
        }
    }
}
