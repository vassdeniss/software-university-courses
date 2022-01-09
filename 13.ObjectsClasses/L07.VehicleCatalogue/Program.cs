using System;
using System.Collections.Generic;
using System.Linq;

namespace L07.VehicleCatalogue
{
    class Catalogue
    {
        public Catalogue()
        {
            TruckList = new List<Truck>();
            CarList = new List<Car>();
        }

        public List<Truck> TruckList { get; set; }
        public List<Car> CarList { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split('/');

            Catalogue catalogueLists = new Catalogue();
            while (cmd[0] != "end")
            {
                string type = cmd[0];
                string brand = cmd[1];
                string model = cmd[2];
                int power = int.Parse(cmd[3]);

                Truck newTruck = new Truck()
                {
                    Brand = brand,
                    Model = model,
                    Weight = power
                };

                Car newCar = new Car()
                {
                    Brand = brand,
                    Model = model,
                    HorsePower = power
                };

                if (type == "Truck")
                    catalogueLists.TruckList.Add(newTruck);
                else
                    catalogueLists.CarList.Add(newCar);

                cmd = Console.ReadLine().Split('/');
            }

            Console.WriteLine("Cars:");
            foreach (Car car in catalogueLists.CarList.OrderBy(b => b.Brand))
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            Console.WriteLine("Trucks:");
            foreach (Truck truck in catalogueLists.TruckList.OrderBy(b => b.Brand))
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
        }
    }
}
