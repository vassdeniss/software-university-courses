using E02.VehiclesExtension.Models;

namespace E02.VehiclesExtension.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQty, double fuelConsume, double tankCapacity) 
            : base(fuelQty, fuelConsume, tankCapacity) { }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}
