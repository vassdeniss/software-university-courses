using System;
using System.Linq;

namespace E10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fieldArray = new int[int.Parse(Console.ReadLine())];
            int[] bugsLocations = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (int i in bugsLocations)
            {
                bool isTooBig = i >= fieldArray.Length;
                bool isTooSmall = i < 0;

                if (!isTooBig && !isTooSmall)
                {
                    fieldArray[i] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int bugIndex = int.Parse(commandArray[0]);
                string direction = commandArray[1];
                int flyLength = int.Parse(commandArray[2]);

                if (bugIndex >= fieldArray.Length || bugIndex < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (fieldArray[bugIndex] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (direction == "right")
                {
                    for (int i = bugIndex + flyLength; i < int.MaxValue; i += flyLength)
                    {
                        if (flyLength == 0)
                        {
                            break;
                        }

                        if (i >= fieldArray.Length)
                        {
                            fieldArray[bugIndex] = 0;
                            break;
                        }

                        if (fieldArray[i] != 1)
                        {
                            fieldArray[i] = 1;
                            fieldArray[bugIndex] = 0;
                            break;
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int i = bugIndex - flyLength; i > int.MinValue; i -= flyLength)
                    {
                        if (flyLength == 0)
                        {
                            break;
                        }

                        if (i < 0)
                        {
                            fieldArray[bugIndex] = 0;
                            break;
                        }

                        if (fieldArray[i] != 1)
                        {
                            fieldArray[i] = 1;
                            fieldArray[bugIndex] = 0;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", fieldArray));
        }
    }
}