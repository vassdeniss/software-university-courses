using System;

namespace EP01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int plunderDays = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0.0;
            for (int i = 1; i <= plunderDays; i++)
            {
                totalPlunder += dailyPlunder;
                if (i % 3 == 0) totalPlunder += dailyPlunder * 0.5;
                if (i % 5 == 0) totalPlunder -= totalPlunder * 0.3;
            }

            if (totalPlunder >= expectedPlunder)
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            else
                Console.WriteLine($"Collected only {totalPlunder / expectedPlunder * 100:f2}% of the plunder.");
        }
    }
}
