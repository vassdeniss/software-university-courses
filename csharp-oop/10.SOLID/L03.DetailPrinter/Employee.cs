namespace L03.DetailPrinter
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
