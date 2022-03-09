using E04.WildFarm.Contracts;
using E04.WildFarm.Models.Foods;
using System;

namespace E04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed) { }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Feed(IFood food)
        {
            if (!(food is Meat))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += 1.0 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
