using System;
using System.Linq;
using System.Collections.Generic;

namespace E11.ArrayManipulator
{
    class Program
    {
        static int[] Exchange(int n, int[] arr)
        {
            if (n >= arr.Length || n < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            int[] changedArray = new int[arr.Length];
            int index = 0;

            for (int i = n + 1; i < arr.Length; i++)
            {
                changedArray[index] = arr[i];
                index++;
            }

            for (int i = 0; i <= n; i++)
            {
                changedArray[index] = arr[i];
                index++;
            }

            return changedArray;
        }

        static void MaxMinEvenOdd(string s, string s1, int[] arr)
        {
            int maxEven = int.MinValue,
                maxOdd = int.MinValue,
                maxEvenIndex = -1,
                maxOddIndex = -1,
                minEven = int.MaxValue,
                minOdd = int.MaxValue,
                minEvenIndex = -1,
                minOddIndex = -1;

            if (s == "max")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] >= maxEven)
                    {
                        maxEven = arr[i];
                        maxEvenIndex = i;
                    }
                    else if (arr[i] % 2 != 0 && arr[i] >= maxOdd)
                    {
                        maxOdd = arr[i];
                        maxOddIndex = i;
                    }
                }
            }
            else if (s == "min")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] <= minEven)
                    {
                        minEven = arr[i];
                        minEvenIndex = i;
                    }
                    else if (arr[i] % 2 != 0 && arr[i] <= minOdd)
                    {
                        minOdd = arr[i];
                        minOddIndex = i;
                    }
                }
            }

            if (s1 == "even" && s == "max")
            {
                Console.WriteLine(maxEvenIndex > -1
                    ? maxEvenIndex.ToString()
                    : "No matches");
            }
            else if (s1 == "odd" && s == "max")
            {
                Console.WriteLine(maxOddIndex > -1
                    ? maxOddIndex.ToString()
                    : "No matches");
            }
            else if (s1 == "even" && s == "min")
            {
                Console.WriteLine(minEvenIndex > -1
                    ? minEvenIndex.ToString()
                    : "No matches");
            }
            else if (s1 == "odd" && s == "min")
            {
                Console.WriteLine(minOddIndex > -1
                    ? minOddIndex.ToString()
                    : "No matches");
            }
        }

        static void FindFirstLastNumbers(int n, string s, string s1, int[] arr)
        {
            if (n > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (n == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            List<int> result = new List<int>();

            if (s1 == "first")
            {
                int count = 0;
                foreach (int num in arr)
                {
                    if (s == "even")
                    {
                        if (num % 2 == 0)
                        {
                            count++;
                            result.Add(num);
                        }
                    }
                    else
                    {
                        if (num % 2 != 0)
                        {
                            count++;
                            result.Add(num);
                        }
                    }

                    if (count == n) break;
                }
            }
            else
            {
                int count = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (s == "even")
                    {
                        if (arr[i] % 2 == 0)
                        {
                            count++;
                            result.Add(arr[i]);
                        }
                    }
                    else
                    {
                        if (arr[i] % 2 != 0)
                        {
                            count++;
                            result.Add(arr[i]);
                        }
                    }

                    if (count == n) break;
                }

                result.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        static void Main(string[] args)
        {
            int[] initialArray =
                Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "exchange")
                {
                    initialArray = Exchange(int.Parse(commands[1]), initialArray);
                }
                else if (commands[0] == "max" || commands[0] == "min")
                {
                    MaxMinEvenOdd(commands[0], commands[1], initialArray);
                }
                else if (commands[0] == "first" || commands[0] == "last")
                {
                    FindFirstLastNumbers(int.Parse(commands[1]), commands[2], commands[0], initialArray);
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", initialArray)}]");
        }
    }
}
