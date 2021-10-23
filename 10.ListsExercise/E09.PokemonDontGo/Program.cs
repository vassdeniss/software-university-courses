using System;
using System.Collections.Generic;
using System.Linq;

namespace E09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distanceList = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();

            while (distanceList.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int numberAtIndex = distanceList[0];
                    removedElements.Add(numberAtIndex);
                    distanceList[0] = distanceList[^1];
                    for (int i = 0; i < distanceList.Count; i++)
                    {
                        if (distanceList[i] <= numberAtIndex)
                        {
                            distanceList[i] += numberAtIndex;
                        }
                        else if (distanceList[i] > numberAtIndex)
                        {
                            distanceList[i] -= numberAtIndex;
                        }
                    }
                }
                else if (index >= distanceList.Count)
                {
                    int numberAtIndex = distanceList[^1];
                    removedElements.Add(numberAtIndex);
                    distanceList[^1] = distanceList[0];
                    for (int i = 0; i < distanceList.Count; i++)
                    {
                        if (distanceList[i] <= numberAtIndex)
                        {
                            distanceList[i] += numberAtIndex;
                        }
                        else if (distanceList[i] > numberAtIndex)
                        {
                            distanceList[i] -= numberAtIndex;
                        }
                    }
                }
                else
                {
                    int numberAtIndex = distanceList[index];
                    removedElements.Add(numberAtIndex);
                    distanceList.RemoveAt(index);
                    for (int i = 0; i < distanceList.Count; i++)
                    {
                        if (distanceList[i] <= numberAtIndex)
                        {
                            distanceList[i] += numberAtIndex;
                        }
                        else if (distanceList[i] > numberAtIndex)
                        {
                            distanceList[i] -= numberAtIndex;
                        }
                    }
                }
            }

            Console.WriteLine(removedElements.Sum());
        }
    }
}
