using System;

namespace L04.BackInThirtyMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes >= 60)
            {
                hour++;
                minutes -= 60; 
            }

            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
