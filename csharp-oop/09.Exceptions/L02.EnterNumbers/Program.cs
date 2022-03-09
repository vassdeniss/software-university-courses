using System;
using System.Collections.Generic;

namespace L02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> nums = new List<int>();
            do
            {
                try
                {
                    nums.Add(ReadNumber(nums, start, end));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (nums.Count < 10);

            Console.WriteLine(string.Join(", ", nums));
        }

        private static int ReadNumber(List<int> nums, int start, int end)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out _))
            {
                throw new FormatException("Invalid Number!");
            }

            int num = int.Parse(input);

            if (nums.Count > 0 && num <= nums[^1])
            {
                throw new ArgumentException($"Your number is not in range {nums[^1]} - 100!");
            } 

            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return num;
        }
    }
}
