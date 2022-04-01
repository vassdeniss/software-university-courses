using System;
using System.Collections.Generic;

namespace E02.Composite
{
    public class GiftComposite : GiftComponent, IGiftOperations
    {
        private readonly List<GiftComponent> components;

        public GiftComposite(string name, int price) : base(name, price)
        {
            components = new List<GiftComponent>();
        }

        public void Add(GiftComponent component) => components.Add(component);

        public void Remove(GiftComponent component) => components.Remove(component);

        public override int CalculatePrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the followings gifts with prices:");

            foreach (GiftComponent component in components)
            {
                total += component.CalculatePrice();
            }

            return total;
        }
    }
}
