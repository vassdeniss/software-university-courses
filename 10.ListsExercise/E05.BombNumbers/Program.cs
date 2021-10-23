using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bombNumbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            int[] numberPower = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            for (int i = 0; i < bombNumbers.Count; i++)
            {
                int specialNumber = numberPower[0];
                if (bombNumbers[i] == specialNumber)
                {
                    int power = numberPower[1];
                    int startRange = i - power, endRange = i + power;

                    if (startRange < 0)
                        startRange = 0;

                    if (endRange > bombNumbers.Count - 1)
                        endRange = bombNumbers.Count - 1;

                    int count = endRange - startRange + 1;

                    bombNumbers.RemoveRange(startRange, count);
                    i = startRange - 1;
                }
            }

            Console.WriteLine(bombNumbers.Sum());
        }
    }
}
