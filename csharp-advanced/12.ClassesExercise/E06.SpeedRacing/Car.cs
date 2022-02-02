using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelRate;
        private double travelledDistance;

        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelRate) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelRate = fuelRate;
        }

        public string Model 
        { 
            get { return model; }
            private set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            private set { fuelAmount = value; }
        }

        public double FuelRate
        {
            get { return fuelRate; }
            private set { fuelRate = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            private set { travelledDistance = value; }
        }

        public void Drive(int distance)
        {
            if (fuelAmount - distance * fuelRate >= 0)
            {
                fuelAmount -= distance * fuelRate;
                travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{model} {fuelAmount:f2} {travelledDistance}";
        }
    }
}
