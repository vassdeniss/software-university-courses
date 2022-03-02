using Shapes.Contracts;
using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private readonly int width;
        private readonly int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');
            for (int i = 0; i < height - 1; i++)
            {
                DrawLine(width, '*', ' ');
            }
            DrawLine(width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width; i++)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}
