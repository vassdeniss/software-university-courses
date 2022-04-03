using System;

namespace Snake.GameObjects
{
    public class FoodHash : Food
    {
        private const char symbol = '#';
        private const int points = 3;

        protected override ConsoleColor Color => ConsoleColor.DarkYellow;

        public FoodHash(Wall wall) : base(wall, symbol, points) { }
    }
}
