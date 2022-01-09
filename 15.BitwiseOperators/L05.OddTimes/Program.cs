using System;
using System.Linq;

namespace L05.OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            // INPUT 1
            // 1 2 3 2 3 1 3
            int[] input = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result ^= input[i];
                // result = 000 (0) XOR 001 (1) = 001
                // result = 001 (1) XOR 010 (2) = 011
                // result = 011 (3) XOR 011 (3) = 000
                // result = 000 (0) XOR 010 (2) = 010
                // result = 010 (2) XOR 011 (3) = 001
                // result = 001 (1) XOR 001 (1) = 000
                // result = 000 (0) XOR 011 (3) = 011
                // 011 = 3 
            }

            Console.WriteLine(result);
        }
    }
}
