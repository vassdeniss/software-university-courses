using E02.VehiclesExtension.Contracts;
using System;

namespace E02.VehiclesExtension.Models
{
    public abstract class Vehicle : IDrivable
    {
        private double fuelQuantity;

        public Vehicle(double fuelQty, double fuelConsume, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsume;
            FuelQuantity = fuelQty;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity) value = 0;
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public void Drive(double km)
        {
            if (km * FuelConsumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= km * FuelConsumption;
            Console.WriteLine($"{GetType().Name} travelled {km} km");
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
