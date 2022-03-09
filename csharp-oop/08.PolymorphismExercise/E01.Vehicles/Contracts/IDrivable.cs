namespace E01.Vehicles.Contracts
{
    public interface IDrivable
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Drive(double km);

        void Refuel(double liters);
    }
}
