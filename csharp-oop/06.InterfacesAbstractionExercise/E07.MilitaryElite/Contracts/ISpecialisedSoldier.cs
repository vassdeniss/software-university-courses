using E07.MilitaryElite.Enums;

namespace E07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corp { get; }
    }
}
