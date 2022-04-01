namespace E02.Composite
{
    public abstract class GiftComponent
    {
        protected string name;
        protected int price;

        protected GiftComponent(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculatePrice();
    }
}
