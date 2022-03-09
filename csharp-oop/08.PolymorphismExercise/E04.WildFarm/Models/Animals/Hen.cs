using E04.WildFarm.Contracts;
using System;

namespace E04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize) { }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Feed(IFood food)
        {
            Weight += 0.35 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
