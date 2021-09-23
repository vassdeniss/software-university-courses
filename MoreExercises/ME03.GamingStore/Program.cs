using System;

namespace ME03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            const decimal OUTFALL_FOUR_PRICE = 39.99m;
            const decimal CS_OG_PRICE = 15.99m;
            const decimal ZPLINTER_ZELL_PRICE = 19.99m;
            const decimal HONORED_TWO_PRICE = 59.99m;
            const decimal ROVERWATCH_PRICE = 29.99m;
            const decimal ROVERWATCH_ORIGIN_PRICE = 39.99m;

            decimal avaliableMoney = decimal.Parse(Console.ReadLine());
            decimal spentMoney = 0.0m;
            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                if (avaliableMoney <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                if (input == "OutFall 4" || input == "CS:OG" || input == "Zplinter Zell"
                    || input == "Honored 2" || input == "RoverWatch" || input == "RoverWatch Origins Edition")
                {
                    switch (input)
                    {
                        case "OutFall 4":
                            if (avaliableMoney >= OUTFALL_FOUR_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= OUTFALL_FOUR_PRICE;
                                spentMoney += OUTFALL_FOUR_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "CS:OG":
                            if (avaliableMoney >= CS_OG_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= CS_OG_PRICE;
                                spentMoney += CS_OG_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Zplinter Zell":
                            if (avaliableMoney >= ZPLINTER_ZELL_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= ZPLINTER_ZELL_PRICE;
                                spentMoney += ZPLINTER_ZELL_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "Honored 2":
                            if (avaliableMoney >= HONORED_TWO_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= HONORED_TWO_PRICE;
                                spentMoney += HONORED_TWO_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch":
                            if (avaliableMoney >= ROVERWATCH_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= ROVERWATCH_PRICE;
                                spentMoney += ROVERWATCH_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                        case "RoverWatch Origins Edition":
                            if (avaliableMoney >= ROVERWATCH_ORIGIN_PRICE)
                            {
                                Console.WriteLine($"Bought {input}");
                                avaliableMoney -= ROVERWATCH_ORIGIN_PRICE;
                                spentMoney += ROVERWATCH_ORIGIN_PRICE;
                            }
                            else
                            {
                                Console.WriteLine("Too Expensive");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }

            if (avaliableMoney <= 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${avaliableMoney:f2}");
            }
        }
    }
}
