using System;
using System.Collections.Generic;
using System.Linq;

namespace ME04.MixedUpLists
{
    class Program
    {
        static void ConcatListsSetConstraints(List<int> one, List<int> two, List<int> concat, List<int> constraints)
        {
            int biggerCount = Math.Max(one.Count, two.Count);
            int smallerCount = Math.Min(one.Count, two.Count);
            int biggerList = one.Count >= two.Count ? 1 : 2;
            for (int i = 0; i < biggerCount; i++)
            {
                if (i < smallerCount)
                {
                    concat.Add(one[i]);
                    concat.Add(two[two.Count - 1 - i]);
                }
                else if (biggerList == 1)
                {
                    constraints.Add(one[i]);
                }
                else if (biggerList == 2)
                {
                    constraints.Add(two[0]);
                    constraints.Add(two[1]);
                    break;
                }
            }
        }

        static void FillResultList(List<int> constraints, List<int> concat, List<int> result)
        {
            int smallerConstraint = int.MaxValue;
            int biggerConstraint = int.MinValue;
            foreach (int n in constraints)
            {
                if (n > biggerConstraint)
                {
                    biggerConstraint = n;
                }

                if (n < smallerConstraint)
                {
                    smallerConstraint = n;
                }
            }

            foreach (int n in concat)
            {
                if (n < biggerConstraint && n > smallerConstraint) result.Add(n);
            }
        }

        static void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int min = i;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                int temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }
        }

        static void Main(string[] args)
        {
            List<int> inputListOne = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> inputListTwo = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> concatLists = new List<int>();
            List<int> constraints = new List<int>();
            List<int> resultList = new List<int>();

            ConcatListsSetConstraints(inputListOne, inputListTwo, concatLists, constraints);
            FillResultList(constraints, concatLists, resultList);
            SelectionSort(resultList);

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
