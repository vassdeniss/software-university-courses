using E02.VehiclesExtension.Contracts;
using E02.VehiclesExtension.Models;

namespace E02.VehiclesExtension.Vehicles
{
    public class Bus : Vehicle, ITransport
    {
        public Bus(double fuelQty, double fuelConsume, double tankCapacity) 
            : base(fuelQty, fuelConsume, tankCapacity) { }

        public bool IsEmpty { get; set; }

        public override double FuelConsumption
            => IsEmpty ? base.FuelConsumption : base.FuelConsumption + 1.4;
    }
}
