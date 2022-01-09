using System;

namespace E04.CharSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < lines; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += input;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
