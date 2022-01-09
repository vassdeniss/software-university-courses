using System;
using System.Collections.Generic;
using System.Linq;

namespace EP03.NeedForSpeedIII
{
    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
            MaxFuel = 75;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
        public int MaxFuel { get; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            int carQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < carQty; i++)
            {
                string[] info = Console.ReadLine().Split('|');
                carList.Add(new Car(info[0], int.Parse(info[1]), int.Parse(info[2])));
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] cmd = input.Split(" : ");
                
                if (cmd[0] == "Drive")
                {
                    Drive(cmd[1], int.Parse(cmd[2]), int.Parse(cmd[3]), carList);
                }
                else if (cmd[0] == "Refuel")
                {
                    Refuel(cmd[1], int.Parse(cmd[2]), carList);
                }
                else if (cmd[0] == "Revert")
                {
                    Revert(cmd[1], int.Parse(cmd[2]), carList);
                }

                input = Console.ReadLine();
            }

            foreach (Car car in carList.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name))
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
        }

        private static void Revert(string name, int kilometers, List<Car> list)
        {
            Car car = list.Single(x => x.Name == name);
            car.Mileage -= kilometers;
            if (car.Mileage < 10000)
            {
                car.Mileage = 10000;
                return;
            }
            Console.WriteLine($"{car.Name} mileage decreased by {kilometers} kilometers");
        }

        static void Refuel(string name, int fuel, List<Car> list)
        {
            Car car = list.Single(x => x.Name == name);

            int usedFuel = fuel;
            if (car.Fuel + fuel > car.MaxFuel)
                usedFuel = fuel - (car.Fuel + fuel - car.MaxFuel);

            car.Fuel += usedFuel;
            Console.WriteLine($"{car.Name} refueled with {usedFuel} liters");
        }

        static void Drive(string name, int distance, int fuel, List<Car> list)
        {
            Car car = list.Single(x => x.Name == name);
            if (car.Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            car.Mileage += distance;
            car.Fuel -= fuel;
            Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

            if (car.Mileage >= 100000)
            {
                list.Remove(car);
                Console.WriteLine($"Time to sell the {car.Name}!");
            }
        }
    }
}
