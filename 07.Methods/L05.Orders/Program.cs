using System;

namespace L05.Orders
{
    class Program
    {
        static decimal CalculatePrice(string product, int quantity)
        {
            decimal price = 0;

            switch(product)
            {
                case "coffee": price = 1.50m * quantity; break;
                case "water": price = 1.00m * quantity; break;
                case "coke": price = 1.40m * quantity; break;
                case "snacks": price = 2.00m * quantity; break;
            }

            return price;
        }

        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculatePrice(product, quantity));
        }
    }
}
