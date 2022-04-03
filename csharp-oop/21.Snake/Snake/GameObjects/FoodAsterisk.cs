namespace Snake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char symbol = '*';
        private const int points = 1;

        public FoodAsterisk(Wall wall) : base(wall, symbol, points) { }
    }
}
