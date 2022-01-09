using System;

namespace E01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            int four = int.Parse(Console.ReadLine());

            int result = ((one + two) / three) * four;
            Console.WriteLine(result);
        }
    }
}
