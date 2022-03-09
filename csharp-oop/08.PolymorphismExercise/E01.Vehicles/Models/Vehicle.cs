using E01.Vehicles.Contracts;
using System;

namespace E01.Vehicles.Models
{
    public abstract class Vehicle : IDrivable
    {
        public Vehicle(double fuelQty, double fuelConsume)
        {
            FuelQuantity = fuelQty;
            FuelConsumption = fuelConsume;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public void Drive(double km)
        {
            if (km * FuelConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= km * FuelConsumption;
            Console.WriteLine($"{GetType().Name} travelled {km} km");
        }

        public virtual void Refuel(double liters) => FuelQuantity += liters;

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
