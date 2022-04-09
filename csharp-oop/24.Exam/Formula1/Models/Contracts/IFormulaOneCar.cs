namespace Formula1.Models.Contracts
{
    public interface IFormulaOneCar
    {
        string Model { get; }

        int Horsepower { get; }

        double EngineDisplacement { get; }

        double RaceScoreCalculator(int laps);
    }
}
