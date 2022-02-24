namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel) { }

        public override double FuelConsumption => 10;
    }
}
