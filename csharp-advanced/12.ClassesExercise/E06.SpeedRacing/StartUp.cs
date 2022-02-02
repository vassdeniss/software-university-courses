using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelRate = double.Parse(data[2]);

                cars.Add(new Car(model, fuelAmount, fuelRate));
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                string model = data[1];
                int km = int.Parse(data[2]);

                Car car = cars.FirstOrDefault(x => x.Model == model);
                car.Drive(km);

                input = Console.ReadLine();
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
