using System;
using System.Linq;

namespace L05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionCount = 0;
            while (exceptionCount < 3)
            {
                string[] data = Console.ReadLine().Split();
                
                if (data[0] == "Replace")
                {
                    try
                    {
                        Replace(nums, data[1], data[2]);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                }
                else if (data[0] == "Print")
                {
                    try
                    {
                        Print(nums, data[1], data[2]);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                }
                else
                {
                    try
                    {
                        Show(nums, data[1]);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        exceptionCount++;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }

        private static void Show(int[] nums, string element)
        {
            ValidateElement(element);

            int index = int.Parse(element);

            ValidateIndex(nums.Length, index);
            Console.WriteLine(nums[index]);
        }

        private static void Print(int[] nums, string start, string end)
        {
            ValidateElement(start);
            ValidateElement(end);

            int startIndex = int.Parse(start);
            int endIndex = int.Parse(end);

            ValidateIndex(nums.Length, startIndex);
            ValidateIndex(nums.Length, endIndex);
            Console.WriteLine(string.Join(", ", nums[startIndex..++endIndex]));
        }

        private static void Replace(int[] nums, string index, string element)
        {
            ValidateElement(element);
            ValidateElement(index);

            int elementIndex = int.Parse(index);

            ValidateIndex(nums.Length, elementIndex);
            nums[elementIndex] = int.Parse(element); 
        }

        private static void ValidateElement(string element)
        {
            if (!int.TryParse(element, out _))
            {
                throw new FormatException("The variable is not in the correct format!");
            }
        }

        private static void ValidateIndex(int lenght, int index)
        {
            if (index < 0 || index >= lenght)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }
    }
}
