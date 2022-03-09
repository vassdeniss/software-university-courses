using E04.WildFarm.Contracts;

namespace E04.WildFarm.Models
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
