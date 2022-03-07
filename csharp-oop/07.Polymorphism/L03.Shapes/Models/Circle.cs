using System;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Radius
        {
            get => radius;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot be negative");
                }

                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
