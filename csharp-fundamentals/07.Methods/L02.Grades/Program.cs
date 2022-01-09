using System;

namespace L02.Grades
{
    class Program
    {
        static string CalculateGrade(double n)
        {
            if (n >= 2.00 && n <= 2.99)
            {
                return "Fail";
            }
            else if (n >= 3.00 && n <= 3.49)
            {
                return "Poor";
            }
            else if (n >= 3.50 && n <= 4.49)
            {
                return "Good";
            }
            else if (n >= 4.50 && n <= 5.49)
            {
                return "Very good";
            }
            else
            {
                return "Excellent";
            }
        }

        static void Main(string[] args)
        {
            string result = CalculateGrade(double.Parse(Console.ReadLine()));
            Console.WriteLine(result);
        }
    }
}
