using E07.MilitaryElite.Contracts;

namespace E07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int code) 
            : base(id, firstName, lastName)
        {
            CodeNumber = code;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"{base.ToString()}\nCode Number: {CodeNumber}";
        }
    }
}
