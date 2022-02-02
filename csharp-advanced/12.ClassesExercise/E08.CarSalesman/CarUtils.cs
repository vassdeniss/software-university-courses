using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class CarUtils
    {
        private static List<Car> cars = new List<Car>();

        public static void AddCar(Car car)
        {
            cars.Add(car);
        }

        public static void PrintCars()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Car car in cars)
            {
                sb.AppendLine($"{car.Model}:");
                sb.AppendLine($"  {car.Engine.Model}:");
                sb.AppendLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement != null) sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
                else sb.AppendLine("    Displacement: n/a");

                if (car.Engine.Efficiency != null) sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
                else sb.AppendLine("    Efficiency: n/a");

                if (car.Weight != null) sb.AppendLine($"  Weight: {car.Weight}");
                else sb.AppendLine($"  Weight: n/a");

                if (car.Color != null) sb.AppendLine($"  Color: {car.Color}");
                else sb.AppendLine($"  Color: n/a");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
