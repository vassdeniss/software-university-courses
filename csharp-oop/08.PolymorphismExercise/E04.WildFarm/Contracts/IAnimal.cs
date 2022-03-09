namespace E04.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        void ProduceSound();

        void Feed(IFood food);
    }
}
