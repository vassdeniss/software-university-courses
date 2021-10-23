using System;

namespace L01.WeekDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int n = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(weekDays[n - 1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
