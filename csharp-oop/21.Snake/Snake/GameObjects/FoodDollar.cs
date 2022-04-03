using System;

namespace Snake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char symbol = '$';
        private const int points = 2;

        protected override ConsoleColor Color => ConsoleColor.DarkGreen;

        public FoodDollar(Wall wall) : base(wall, symbol, points) { }
    }
}
