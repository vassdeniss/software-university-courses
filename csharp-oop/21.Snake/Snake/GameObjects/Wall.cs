using System;

namespace Snake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY) { }

        public void InitializeWall()
        {
            InitializeHorizontal(0);
            InitializeHorizontal(TopY);

            InitializeVertical(0);
            InitializeVertical(LeftX - 1);
        }

        private void InitializeVertical(int n)
        {
            for (int i = 0; i < TopY; i++)
            {
                Draw(n, i, WALL_SYMBOL);
            }
        }

        private void InitializeHorizontal(int n)
        {
            for (int i = 0; i < LeftX; i++)
            {
                Draw(i, n, WALL_SYMBOL);
            }
        }
    }
}
