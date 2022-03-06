using E07.MilitaryElite.Contracts;

namespace E07.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string name, int hours)
        {
            PartName = name;
            HoursWorked = hours;
        }

        public string PartName { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
