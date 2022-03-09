using E02.VehiclesExtension.Contracts;
using E02.VehiclesExtension.Vehicles;
using System;

namespace E02.VehiclesExtension.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            RunCommands(car, truck, bus);
            Console.WriteLine($"{car}\n{truck}\n{bus}");
        }

        private void RunCommands(Car car, Truck truck, Bus bus)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                IDrivable vehicle = GetVehicle(car, truck, bus, commands[1]);
                try
                {
                    if (commands[0] == "Drive")
                    {
                        vehicle.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        bus.Drive(double.Parse(commands[2]));
                        bus.IsEmpty = false;
                    }
                    else vehicle.Refuel(double.Parse(commands[2]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private IDrivable GetVehicle(Car car, Truck truck, Bus bus, string type)
        {
            return type switch
            {
                "Car" => car,
                "Truck" => truck,
                "Bus" => bus,
                _ => null
            };
        }
    }
}
