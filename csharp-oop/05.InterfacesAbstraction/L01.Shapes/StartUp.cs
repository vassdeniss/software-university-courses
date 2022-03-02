using Shapes.Contracts;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            circle.Draw();
            rect.Draw();
        }
    }
}
