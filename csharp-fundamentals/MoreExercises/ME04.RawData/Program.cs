using System;
using System.Collections.Generic;
using System.Linq;

namespace ME04.RawData
{
    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car()
        {
            Engine = new Engine();
            Cargo = new Cargo();
        }

        public void Print(List<Car> list, string type)
        {
            IEnumerable<Car> wantedCars;
            if (type == "fragile")
            {
                wantedCars = list.Where(car => car.Cargo.CargoType == type)
                    .Where(car => car.Cargo.CargoWeight < 1000);
            }
            else
            {
                wantedCars = list.Where(car => car.Cargo.CargoType == type)
                    .Where(car => car.Engine.EnginePower > 250);
            }

            foreach (Car car in wantedCars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int carQty = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();
            Car car = new Car();
            for (int i = 0; i < carQty; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];
                int engnineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Engine engine = new Engine()
                {
                    EngineSpeed = engnineSpeed,
                    EnginePower = enginePower
                };

                Cargo cargo = new Cargo()
                {
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                Car newCar = new Car()
                {
                    Model = model,
                    Engine = engine,
                    Cargo = cargo
                };

                carList.Add(newCar);
            }

            car.Print(carList, Console.ReadLine());
        }
    }
}
