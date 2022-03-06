using E07.MilitaryElite.Contracts;

namespace E07.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string ID { get; }

        public string FirstName { get; }
         
        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID}";
        }
    }
}
