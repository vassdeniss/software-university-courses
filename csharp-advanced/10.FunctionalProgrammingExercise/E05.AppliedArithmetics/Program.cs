using System;
using System.Linq;

namespace E05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                Action<int[]> action = GetAction(input);
                action(nums);
                input = Console.ReadLine();
            }
        }

        private static Action<int[]> GetAction(string input)
        {
            return input switch
            {
                "add" => x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] += 1;
                    }
                }
                ,
                "multiply" => x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] *= 2;
                    }
                }
                ,
                "subtract" => x =>
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] -= 1;
                    }
                }
                ,
                "print" => x => Console.WriteLine(string.Join(" ", x)),
                _ => null,
            };
        }
    }
}
