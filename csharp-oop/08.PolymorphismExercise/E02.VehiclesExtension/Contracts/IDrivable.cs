namespace E02.VehiclesExtension.Contracts
{
    public interface IDrivable
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        void Drive(double km);

        void Refuel(double liters);
    }
}
