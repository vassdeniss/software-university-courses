namespace L03.DetailPrinter
{
    public class Supervisor : Employee
    {
        private bool isOnVacation;

        public Supervisor(string name, bool isOnVacation) : base(name)
        {
            this.isOnVacation = isOnVacation;
        }

        public override string ToString()
        {
            string result = isOnVacation ? "is" : "is not";
            return $"{base.ToString()} {result} on vacation";
        }
    }
}
