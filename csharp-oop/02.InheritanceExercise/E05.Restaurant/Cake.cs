namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal CAKE_PRICE = 5;
        private const double CAKE_GRAMS = 250;
        private const double CAKE_CALORIES = 1000;

        public Cake(string name) : base(name, CAKE_PRICE, CAKE_GRAMS, CAKE_CALORIES) { }
    }
}
