using E04.WildFarm.Contracts;
using E04.WildFarm.Models.Foods;
using System;

namespace E04.WildFarm.Factories
{
    public static class FoodFactory
    {
        public static IFood CreateFood(string args)
        {
            string[] data = args.Split();

            string type = data[0];
            int quantity = int.Parse(data[1]);

            IFood food = null;
            switch (type)
            {
                case "Fruit": food = new Fruit(quantity); break;
                case "Meat": food = new Meat(quantity); break;
                case "Seeds": food = new Seeds(quantity); break;
                case "Vegetable": food = new Vegetable(quantity); break;
            }

            return food;
        }
    }
}
