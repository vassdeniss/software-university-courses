using System;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be negative");
                }

                height = value;
            }
        }


        public int Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative");
                }

                width = value;
            }
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (height + width);
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
