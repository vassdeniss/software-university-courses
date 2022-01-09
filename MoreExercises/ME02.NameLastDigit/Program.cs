using System;

namespace ME02.NameLastDigit
{
    class Program
    {
        static string LastDigit(int num)
        {
            string result = String.Empty;
            int lastDigit = num % 10;
            switch (lastDigit)
            {
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigit(num));
        }
    }
}
