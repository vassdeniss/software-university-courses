using System;

namespace E06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);

            int factorialSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int factorialCurrent = 1;

                int currentNum = Convert.ToInt32(char.GetNumericValue(input[i]));
                
                for (int j = 1; j <= currentNum; j++)
                {
                    factorialCurrent *= j;
                }

                factorialSum += factorialCurrent;
            }

            if (factorialSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
