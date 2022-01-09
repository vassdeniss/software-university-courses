using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.AnonymousThreat
{
    class Program
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Merge(List<string> list, int start, int end)
        {
            if (start < 0) start = 0;

            if (end >= list.Count) end = list.Count - 1;                         

            int startString = start;
            int timesIterate = end - start;
            int iterator = start + 1;
            for (int i = 0; i < timesIterate; i++)
            {
                list[startString] += list[iterator];
                list.RemoveAt(iterator);
            }
        }

        static void Divide(List<string> list, int index, int partitions)
        {
            if (index < 0) index = 0;

            if (index >= list.Count) index = list.Count - 1;

            string word = list[index];
            int numAtIndexLength = list[index].Length;
            int lettersDivideCount = numAtIndexLength / partitions;
            int timesToSplit = partitions;

            if (numAtIndexLength % partitions == 0)
            {
                int iterator = 1;
                while (timesToSplit > 0)
                {
                    int count = 1;
                    string insert = string.Empty;
                    while (count <= lettersDivideCount)
                    {
                        insert += word[^iterator];
                        count++;
                        iterator++;                        
                    }
                    insert = Reverse(insert);
                    list.Insert(1, insert);
                    timesToSplit--;
                }
                list.RemoveAt(index);
            }
            else if (numAtIndexLength % partitions != 0)
            {
                int tuneLength = word.Length;
                int excessLetters = 0;
                while (tuneLength % partitions != 0)
                {
                    tuneLength--;
                    excessLetters++;
                }
                tuneLength /= partitions;

                int iterator = 1;
                int loopForLongestPartition = tuneLength + excessLetters;
                bool isLongestIn = false;
                while (timesToSplit > 0)
                {
                    string insert = string.Empty;

                    if (!isLongestIn)
                    {
                        for (int i = 0; i < loopForLongestPartition; i++)
                        {
                            insert += word[^iterator];
                            iterator++;
                        }

                        insert = Reverse(insert);
                        list.Insert(1, insert);
                        timesToSplit--;

                        isLongestIn = true;
                        continue;
                    }

                    int count = 1;
                    while (count <= lettersDivideCount)
                    {
                        insert += word[^iterator];
                        count++;
                        iterator++;
                    }
                    insert = Reverse(insert);
                    list.Insert(1, insert);
                    timesToSplit--;
                }
                list.RemoveAt(index);
            }
        }

        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "3:1")
            {
                if (commands[0] == "merge") Merge(input, int.Parse(commands[1]), int.Parse(commands[2]));
                else if (commands[0] == "divide") Divide(input, int.Parse(commands[1]), int.Parse(commands[2]));

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
