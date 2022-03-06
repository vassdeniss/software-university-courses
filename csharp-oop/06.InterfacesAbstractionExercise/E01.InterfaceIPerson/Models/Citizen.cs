using PersonInfo.Contracts;

namespace PersonInfo.Models
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => name;

        public int Age => age;
    }
}
