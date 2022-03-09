using E02.VehiclesExtension.Models;

namespace E02.VehiclesExtension.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQty, double fuelConsume, double tankCapacity) 
            : base(fuelQty, fuelConsume, tankCapacity) { }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            if (liters + FuelQuantity <= TankCapacity)
            {
                liters *= 0.95;
            }

            base.Refuel(liters);
        }
    }
}
