using E07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace E07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;

        public LieutenantGeneral(string id,
                                 string firstName,
                                 string lastName,
                                 decimal salary,
                                 List<IPrivate> privateList) 
            : base(id, firstName, lastName, salary)
        {
            privates = privateList;
        }

        public IReadOnlyCollection<IPrivate> Privates => privates.AsReadOnly();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            privates.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString().TrimEnd();
        }
    }
}
