using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E06.VehicleCatalogue
{
    class Program
    {
        internal enum VehicleType
        {
            Car, Truck
        }

        internal class Vehicle
        {
            public Vehicle(VehicleType type, string model, string color, int horsePower)
            {
                Type = type;
                Model = model;
                Color = color;
                HorsePower = horsePower;
            }

            public VehicleType Type { get; }
            public string Model { get; }
            public string Color { get; }
            public int HorsePower { get; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Type: {Type}");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"Color: {Color}");
                sb.AppendLine($"Horsepower: {HorsePower}");
                return sb.ToString().TrimEnd();
            }
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<Vehicle> vehicleList = new List<Vehicle>();
            while (input[0] != "End")
            {
                bool isParsable = Enum.TryParse(input[0], true, out VehicleType type);

                if (isParsable)
                {
                    string model = input[1];
                    string color = input[2];
                    int horsePower = int.Parse(input[3]);
                    vehicleList.Add(new Vehicle(
                        type, model, color, horsePower
                    ));
                }

                input = Console.ReadLine().Split();
            }

            input = Console.ReadLine().Split();
            while (input[0] != "Close")
            {
                Vehicle wantedCar = vehicleList.FirstOrDefault(car => car.Model == input[0]);
                Console.WriteLine(wantedCar);
                input = Console.ReadLine().Split();
            }

            IEnumerable<Vehicle> cars = vehicleList.Where(car => car.Type == VehicleType.Car);
            IEnumerable<Vehicle> trucks = vehicleList.Where(truck => truck.Type == VehicleType.Truck);
            double carsAvgHp = cars.Any() ? cars.Average(car => car.HorsePower) : 0.0;
            double trucksAvgHp = trucks.Any() ? trucks.Average(car => car.HorsePower) : 0.0;
            Console.WriteLine($"Cars have average horsepower of: {carsAvgHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvgHp:f2}.");
        }
    }
}
