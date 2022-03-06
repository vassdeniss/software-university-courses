using E07.MilitaryElite.Contracts;
using E07.MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace E07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;

        public Engineer(string id,
                        string firstName,
                        string lastName,
                        decimal salary,
                        Corps corp,
                        List<IRepair> repairList) 
            : base(id, firstName, lastName, salary, corp)
        {
            repairs = repairList;
        }

        public IReadOnlyCollection<IRepair> Repairs => repairs.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            repairs.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().TrimEnd();
        }
    }
}
