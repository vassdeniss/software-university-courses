using E04.WildFarm.Contracts;
using E04.WildFarm.Models.Foods;
using System;

namespace E04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion) { }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Feed(IFood food)
        {
            if (!(food is Vegetable) && !(food is Fruit))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += 0.1 * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
