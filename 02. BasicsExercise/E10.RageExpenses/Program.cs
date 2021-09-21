using System;

namespace E10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double trashedKeyboards = 0;
            double rageExpense = 0.0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    rageExpense += headsetPrice;
                    rageExpense += mousePrice;
                    rageExpense += keyboardPrice;
                    trashedKeyboards += 1.5;
                    if (trashedKeyboards % 3 == 0)
                    {
                        rageExpense += displayPrice;
                        trashedKeyboards = 0;
                    }
                }
                else if (i % 2 == 0)
                {
                    rageExpense += headsetPrice;
                }
                else if (i % 3 == 0)
                {
                    rageExpense += mousePrice;
                }
            }

            Console.WriteLine($"Rage expenses: {rageExpense:f2} lv.");
        }
    }
}
