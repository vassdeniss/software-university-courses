namespace E06.FoodShortage.Contracts
{
    public interface IBuyer
    {
        abstract void BuyFood();

        abstract int Food { get; }
    }
}
