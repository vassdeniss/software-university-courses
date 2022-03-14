namespace L04.Recharge
{
    public abstract class Worker : IWorker
    {
        public Worker(string id)
        {
            ID = id;
        }

        public string ID { get; }

        public int WorkingHours { get; private set; }

        public virtual void Work(int hours)
        {
            WorkingHours += hours;
        }
    }
}
