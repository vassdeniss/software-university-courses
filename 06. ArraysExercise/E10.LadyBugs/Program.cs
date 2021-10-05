using System;
using System.Linq;

namespace E10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldArraySize = int.Parse(Console.ReadLine());
            int[] fieldArray = new int[fieldArraySize];
            int[] bugsLocations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (int i in bugsLocations)
            {
                if (i >= 0 && i < fieldArraySize)
                {
                    fieldArray[i] = 1;
                }
            }

            string[] commandArray = Console.ReadLine().Split();

            while (commandArray[0] != "end")
            {
                int bugIndex = int.Parse(commandArray[0]);
                string direction = commandArray[1];
                int flyLength = int.Parse(commandArray[2]);
                bool hasMoved = false;

                while (bugIndex >= 0 && bugIndex < fieldArraySize && fieldArray[bugIndex] != 0)
                {
                    if (!hasMoved)
                    {
                        fieldArray[bugIndex] = 0;
                        hasMoved = true;
                    }

                    if (direction == "left")
                    {
                        bugIndex -= flyLength;
                        if (bugIndex >= 0 && bugIndex < fieldArraySize)
                        {
                            if (fieldArray[bugIndex] == 0)
                            {
                                fieldArray[bugIndex] = 1;
                                break;
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        bugIndex += flyLength;
                        if (bugIndex >= 0 && bugIndex < fieldArraySize)
                        {
                            if (fieldArray[bugIndex] == 0)
                            {
                                fieldArray[bugIndex] = 1;
                                break;
                            }
                        }
                    }
                } 

                commandArray = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", fieldArray));
        }
    }
}
