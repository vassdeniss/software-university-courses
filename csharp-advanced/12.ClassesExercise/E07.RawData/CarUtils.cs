using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public static class CarUtils
    {
        private static List<Car> cars = new List<Car>();

        public static void AddCar(Car car)
        {
            cars.Add(car);
        }

        public static void FilterCars(string type)
        {
            switch (type)
            {
                case "fragile":
                    cars = cars
                        .Where(x => x.Cargo.Type == "fragile"
                            && x.Tires.Any(x => x.Pressure < 1))
                        .ToList();
                    break;
                case "flammable":
                    cars = cars
                        .Where(x => x.Cargo.Type == "flammable"
                            && x.Engine.Power > 250)
                        .ToList();
                    break;
            }
        }

        public static void PrintCars()
        {
            cars.ForEach(x => Console.WriteLine(x.Model));
        }
    }
}
