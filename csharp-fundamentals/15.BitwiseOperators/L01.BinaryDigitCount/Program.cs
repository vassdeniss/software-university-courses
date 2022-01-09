using System;
using System.Collections.Generic;
using System.Linq;

namespace L01.BinaryDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int digit = int.Parse(Console.ReadLine());

            string binaryDigit = ConvertToBinary(num);

            Console.WriteLine(FindDigits(binaryDigit, digit));
        }

        static int FindDigits(string binaryDigit, int digit)
        {
            int count = 0;
            foreach (char c in binaryDigit)
            {
                double numC = char.GetNumericValue(c);
                if (numC == digit) count++;
            }

            return count;
        }

        static string ConvertToBinary(int n)
        {
            string binaryNumber = string.Empty;

            while (n > 0)
            {
                binaryNumber += n % 2;
                n /= 2;
            }

            IEnumerable<char> binaryNumberArray = binaryNumber.ToCharArray().Reverse();

            return new string(binaryNumberArray.ToArray());
        }
    }
}
