using Shapes.Contracts;
using Shapes.Models;
using System;

namespace Shapes.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            Shape rec = new Rectangle(4, 30);
            Console.WriteLine(rec.CalculatePerimeter());
            Console.WriteLine(rec.CalculateArea());
            Console.WriteLine(rec.Draw());

            Shape circle = new Circle(5);
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}
