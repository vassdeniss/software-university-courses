namespace E01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQty, double fuelConsume) : base(fuelQty, fuelConsume + 1.6) { }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
