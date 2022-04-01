using System;

namespace E01.Prototype
{
    public class Sandwich : SandwichPrototype
    {
        private readonly string[] ingridients;

        public Sandwich(params string[] ingridients)
        {
            this.ingridients = ingridients;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning with ingridients: {GetIngridients()}");

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngridients()
        {
            return string.Join(", ", ingridients);
        }
    }
}
