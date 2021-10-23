using System;

namespace E07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalCoins = 0.0;

            while (input != "Start")
            {
                double coins = double.Parse(input);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5
                    || coins == 1 || coins == 2)
                {
                    totalCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins:f1}");
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Nuts" || input == "Water" || input == "Crisps"
                    || input == "Soda" || input == "Coke")
                {
                    switch (input)
                    {
                        case "Nuts":
                            if (totalCoins < 2) { Console.WriteLine("Sorry, not enough money"); }
                            else { totalCoins -= 2; Console.WriteLine($"Purchased {input.ToLower()}"); }
                            break;
                        case "Water":
                            if (totalCoins < 0.7) { Console.WriteLine("Sorry, not enough money"); }
                            else { totalCoins -= 0.7; Console.WriteLine($"Purchased {input.ToLower()}"); }
                            break;
                        case "Crisps":
                            if (totalCoins < 1.5) { Console.WriteLine("Sorry, not enough money"); }
                            else { totalCoins -= 1.5; Console.WriteLine($"Purchased {input.ToLower()}"); }
                            break;
                        case "Soda":
                            if (totalCoins < 0.8) { Console.WriteLine("Sorry, not enough money"); }
                            else { totalCoins -= 0.8; Console.WriteLine($"Purchased {input.ToLower()}"); }
                            break;
                        case "Coke":
                            if (totalCoins < 1) { Console.WriteLine("Sorry, not enough money"); }
                            else { totalCoins -= 1; Console.WriteLine($"Purchased {input.ToLower()}"); }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = Console.ReadLine(); 
            }

            Console.WriteLine($"Change: {totalCoins:f2}");
        }
    }
}
