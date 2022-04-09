namespace Formula1.Models.Contracts
{
    public interface IPilot
    {
        string FullName { get; }

        IFormulaOneCar Car { get; }

        int NumberOfWins { get; }

        bool CanRace { get; }

        void AddCar(IFormulaOneCar car);

        void WinRace();
    }
}
