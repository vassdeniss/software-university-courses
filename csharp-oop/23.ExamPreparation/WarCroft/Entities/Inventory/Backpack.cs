namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int DEFAULT_CAPACITY = 100;

        public Backpack() : base(DEFAULT_CAPACITY) { }
    }
}
