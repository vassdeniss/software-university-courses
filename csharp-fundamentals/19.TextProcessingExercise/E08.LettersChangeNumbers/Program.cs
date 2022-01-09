using System;

namespace E08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            foreach (string s in inputStrings) sum += CalculateNumber(s);

            Console.WriteLine($"{sum:f2}");
        }

        static double CalculateNumber(string s)
        {
            char letterBefore = s[0];
            double number = double.Parse(s[1..^1]);
            char letterAfter = s[^1];

            if (char.IsUpper(letterBefore)) number /= char.ToUpper(letterBefore) - 64;
            else if (char.IsLower(letterBefore)) number *= char.ToUpper(letterBefore) - 64;

            if (char.IsUpper(letterAfter)) number -= char.ToUpper(letterAfter) - 64;
            else if (char.IsLower(letterAfter)) number += char.ToUpper(letterAfter) - 64;

            return number;
        }
    }
}
