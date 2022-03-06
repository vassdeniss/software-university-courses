using E07.MilitaryElite.Contracts;
using E07.MilitaryElite.Enums;

namespace E07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id,
                                  string firstName,
                                  string lastName,
                                  decimal salary,
                                  Corps corp) 
            : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }

        public Corps Corp { get; }

        public override string ToString()
        {
            return $"{base.ToString()}\nCorps: {Corp}";
        }
    }
}
