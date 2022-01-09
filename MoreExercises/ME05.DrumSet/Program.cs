using System;
using System.Collections.Generic;
using System.Linq;

namespace ME05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            List<int> initialQuality = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> usedQuality = new List<int>(initialQuality);
            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int power = int.Parse(command);

                for (int i = 0; i < usedQuality.Count; i++)
                {
                    usedQuality[i] -= power;
                    if (usedQuality[i] <= 0)
                    {
                        int price = initialQuality[i] * 3;
                        if (money - price > 0)
                        {
                            money -= price;
                            usedQuality[i] = initialQuality[i];
                        }
                        else if (money - price <= 0)
                        {
                            initialQuality.RemoveAt(i);
                            usedQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", usedQuality));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}
