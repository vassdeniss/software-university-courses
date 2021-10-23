using System;
using System.Linq;
using System.Collections.Generic;

namespace L03.MergingLists
{
    class Program
    {
        static void AddRemainingNumbers(List<int> listOne, List<int> listTwo, List<int> concatList)
        {
            if (listOne.Count > listTwo.Count)
            {
                listOne.RemoveRange(0, listTwo.Count);
                foreach (int n in listOne)
                {
                    concatList.Add(n);
                }
            }
            else if (listTwo.Count > listOne.Count)
            {
                listTwo.RemoveRange(0, listOne.Count);
                foreach (int n in listTwo)
                {
                    concatList.Add(n);
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine()
                .Split().Select(int.Parse).ToList();

            List<int> concatList = new List<int>();

            int lengthSmaller = Math.Min(listOne.Count, listTwo.Count);
            int lengthBigger = Math.Max(listOne.Count, listTwo.Count);

            for (int i = 0; i < lengthSmaller; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    concatList.Add(listOne[i]);
                    concatList.Add(listTwo[j]);
                }
            }

            AddRemainingNumbers(listOne, listTwo, concatList);

            Console.WriteLine(string.Join(" ", concatList));
        }
    }
}
