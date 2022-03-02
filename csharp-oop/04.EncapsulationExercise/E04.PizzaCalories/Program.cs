using System;

namespace E04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split();

                try
                {
                    switch (data[0])
                    {
                        case "Pizza":
                            pizza = new Pizza(data[1]);
                            break;
                        case "Dough":
                            pizza.AddDough(new Dough(data[1], data[2], int.Parse(data[3])));
                            break;
                        case "Topping":
                            pizza.AddTopping(new Topping(data[1], int.Parse(data[2])));
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(pizza);
        }
    }
}
