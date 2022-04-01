using System;

namespace E02.Composite
{
    public class GiftSingle : GiftComponent
    {
        public GiftSingle(string name, int price) : base(name, price) { }

        public override int CalculatePrice()
        {
            Console.WriteLine($"{name} with price {price}");

            return price;
        }
    }
}
