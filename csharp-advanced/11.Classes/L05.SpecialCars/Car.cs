using System;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
                   Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }
        public Engine Engine { get; private set; }
        public Tire[] Tires { get; private set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (FuelConsumption * distance / 100) >= 0)
                FuelQuantity -= distance * FuelConsumption / 100;
        }

        public static Func<Car, bool> GetSpecialCars()
        {
            return x =>
                x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tires.Sum(y => y.Pressure) >= 9.0
                && x.Tires.Sum(y => y.Pressure) <= 10.0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"HorsePowers: {Engine.HorsePower}");
            sb.AppendLine($"FuelQuantity: {FuelQuantity}");
            
            return sb.ToString();
        }
    }
}
