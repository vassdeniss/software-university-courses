using System;

namespace E09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyAmount = double.Parse(Console.ReadLine());
            int studentAmount = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double extraSabers = Math.Ceiling(studentAmount * 0.1);

            double totalSaberPrice = lightSaberPrice * (studentAmount + extraSabers);
            double totalRobePrice = robePrice * studentAmount;
            double totalBeltPrice = 0.0;

            for (int i = 1; i <= studentAmount; i++)
            {
                if (i % 6 != 0)
                {
                    totalBeltPrice += beltPrice;
                }
            }

            double totalMoneyNeeded = totalSaberPrice + totalRobePrice + totalBeltPrice;

            if (totalMoneyNeeded <= moneyAmount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {(totalMoneyNeeded - moneyAmount):f2}lv more.");
            }
        }
    }
}
