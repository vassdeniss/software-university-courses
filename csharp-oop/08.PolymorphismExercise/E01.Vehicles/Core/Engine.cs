using E01.Vehicles.Contracts;
using E01.Vehicles.Models;
using System;

namespace E01.Vehicles.Core
{
    public class Engine : IRunnable
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            IDrivable car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            IDrivable truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            RunCommands(car, truck);

            Console.WriteLine($"{car}\n{truck}");
        }

        private void RunCommands(IDrivable car, IDrivable truck)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "Drive")
                {
                    try
                    {
                        if (commands[1] == "Car")
                            car.Drive(double.Parse(commands[2]));
                        else
                            truck.Drive(double.Parse(commands[2]));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    if (commands[1] == "Car")
                        car.Refuel(double.Parse(commands[2]));
                    else
                        truck.Refuel(double.Parse(commands[2]));
                }
            }
        }
    }
}
