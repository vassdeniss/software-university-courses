using System;

namespace BE07.HousePainting {
    class Program {
        static void Main(string[] args) {
            const double GREEN_PAINT_COST = 3.4;
            const double RED_PAINT_COST = 4.3;
            const double DOOR_SIZE_WIDTH = 1.2;
            const double DOOR_SIZE_HEIGHT = 2;
            const double DOOR_AREA = DOOR_SIZE_WIDTH * DOOR_SIZE_HEIGHT;
            const double WINDOW_SIZE = 1.5;
            const double WINDOW_AREA = WINDOW_SIZE * WINDOW_SIZE;

            double X = double.Parse(Console.ReadLine());
            double Y = double.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());

            double frontWallArea = X * X;
            double backWallArea = frontWallArea - DOOR_AREA;
            double leftRightWallArea = ((X * Y) - WINDOW_AREA) * 2;
            double roofArea = (X * Y) * 2 + (((X * H) /2) * 2);
            double neededLitresGreen = (frontWallArea + backWallArea + leftRightWallArea) / GREEN_PAINT_COST;
            double neededLitresRed = roofArea / RED_PAINT_COST;
            Console.WriteLine($"{neededLitresGreen:f2}\n{neededLitresRed:f2}");
        }
    }
}
