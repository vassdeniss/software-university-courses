using System;

namespace L03.ExactRealNumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTimes = int.Parse(Console.ReadLine());
            decimal result = 0;

            for (int i = 0; i < numTimes; i++)
            {
                result += decimal.Parse(Console.ReadLine()); 
            }

            Console.WriteLine(result);
        }
    }
}
