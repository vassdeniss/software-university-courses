using E05.BirthdayCelebrations.Contracts;

namespace E05.BirthdayCelebrations.Models
{
    public class Pet : ILiving
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
