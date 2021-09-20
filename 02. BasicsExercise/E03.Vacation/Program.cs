using System;

namespace E03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleQty = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string stayDay = Console.ReadLine();

            double price = 0.0;

            switch (groupType)
            {
                case "Students":
                    switch (stayDay)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    price *= peopleQty;
                    if (peopleQty >= 30) { price *= 0.85; }
                    break;
                case "Business":
                    switch (stayDay)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                    }
                    double discountPrice = price * 10;
                    price *= peopleQty;
                    if (peopleQty >= 100) { price -= discountPrice; }
                    break;
                case "Regular":
                    switch (stayDay)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                    }
                    price *= peopleQty;
                    if (peopleQty >= 10 && peopleQty <= 20) { price *= 0.95; }
                    break;
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
