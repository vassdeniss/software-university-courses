using E07.MilitaryElite.Contracts;
using E07.MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace E07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id,
                        string firstName,
                        string lastName,
                        decimal salary,
                        Corps corp,
                        List<IMission> missionList) 
            : base(id, firstName, lastName, salary, corp)
        {
            missions = missionList;
        }

        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            missions.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().TrimEnd();
        }
    }
}
