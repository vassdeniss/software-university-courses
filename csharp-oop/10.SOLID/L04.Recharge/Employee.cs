namespace L04.Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id) { }

        public void Sleep() { }
    }
}
