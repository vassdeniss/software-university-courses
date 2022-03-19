namespace EXAM01.VaccOps.Models
{
    public class Patient
    {
        public Patient(string name, int height, int age, string town)
        {
            Name = name;
            Height = height;
            Age = age;
            Town = town;
        }

        public Doctor Doctor { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
    }
}
