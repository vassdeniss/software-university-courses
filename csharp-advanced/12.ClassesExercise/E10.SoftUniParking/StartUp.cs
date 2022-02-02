using System;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            Car car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());

            Parking parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));

            Console.WriteLine(parking.AddCar(car));

            Console.WriteLine(parking.AddCar(car2));

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
        }
    }
}
