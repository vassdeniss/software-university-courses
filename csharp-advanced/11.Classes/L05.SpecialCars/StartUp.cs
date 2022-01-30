using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<Tire[]> tires = new List<Tire[]>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] data = input.Split();
                Tire[] tireArr = new Tire[4]
                {
                    new Tire(int.Parse(data[0]), double.Parse(data[1])),
                    new Tire(int.Parse(data[2]), double.Parse(data[3])),
                    new Tire(int.Parse(data[4]), double.Parse(data[5])),
                    new Tire(int.Parse(data[6]), double.Parse(data[7]))
                };

                tires.Add(tireArr);
            }

            List<Engine> engines = new List<Engine>();
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] data = input.Split();
                int power = int.Parse(data[0]);
                double capacity = double.Parse(data[1]);

                engines.Add(new Engine(power, capacity));
            }

            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] data = input.Split();
                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                double fuelQty = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                Engine engine = engines[int.Parse(data[5])];
                Tire[] tiresArr = tires[int.Parse(data[6])];

                cars.Add(new Car(make, model, year, fuelQty, fuelConsumption, engine, tiresArr));
            }

            List<Car> specialCars = cars.Where(Car.GetSpecialCars()).ToList();
            specialCars.ForEach(x => x.Drive(20));
            specialCars.ForEach(x => Console.Write(x));
        }
    }
}
