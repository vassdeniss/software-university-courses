using System;
using System.Collections.Generic;

namespace ME03.SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumePerKilo { get; set; }
        public int TraveledDistance { get; set; }

        public void Drive(List<Car> list, string model, int kilos)
        {
            Car currCar = list.Find(car => car.Model == model);
            int currIndex = list.IndexOf(currCar);
            double totalFuelneeded = currCar.FuelConsumePerKilo * kilos;
            if (currCar.FuelAmount >= totalFuelneeded)
            {
                currCar.FuelAmount -= totalFuelneeded;
                currCar.TraveledDistance += kilos;
                list[currIndex] = currCar;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int carQty = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();
            for (int i = 0; i < carQty; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumePerKilo = double.Parse(data[2]);

                carList.Add(new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumePerKilo = fuelConsumePerKilo,
                    TraveledDistance = 0
                });
            }

            Car car = new Car();
            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "End")
            {
                car.Drive(carList, cmd[1], int.Parse(cmd[2]));
                cmd = Console.ReadLine().Split();
            }

            foreach (Car carPrint in carList)
            {
                Console.WriteLine($"{carPrint.Model} {carPrint.FuelAmount:f2} {carPrint.TraveledDistance}");
            }
        }
    }
}
