using System;

namespace CarManager
{
    public class Car
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelAmount;
        private double fuelCapacity;

        private Car() => FuelAmount = 0;

        public Car(string make, string model, double fuelConsumption, double fuelCapacity) : this()
        {
            Make = make;
            Model = model;
            FuelConsumption = fuelConsumption;
            FuelCapacity = fuelCapacity;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Make cannot be null or empty!");
                }

                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null or empty!");
                }

                model = value;
            }
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be zero or negative!");
                }

                fuelConsumption = value;
            }
        }

        public double FuelAmount
        {
            get => fuelAmount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel amount cannot be negative!");
                }

                fuelAmount = value;
            }
        }

        public double FuelCapacity
        {
            get => fuelCapacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel capacity cannot be zero or negative!");
                }

                fuelCapacity = value;
            }
        }

        public void Refuel(double fuelToRefuel)
        {
            if (fuelToRefuel <= 0)
            {
                throw new ArgumentException("Fuel amount cannot be zero or negative!");
            }

            FuelAmount += fuelToRefuel;

            if (FuelAmount > FuelCapacity)
            {
                FuelAmount = FuelCapacity;
            }
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance / 100 * FuelConsumption;

            if (fuelNeeded > FuelAmount)
            {
                throw new InvalidOperationException("You don't have enough fuel to drive!");
            }

            FuelAmount -= fuelNeeded;
        }
    }
}
