namespace E01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQty, double fuelConsume) : base(fuelQty, fuelConsume + 0.9) { }
    }
}
