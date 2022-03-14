namespace L04.Recharge
{
    public interface IWorker
    {
        string ID { get; }

        int WorkingHours { get; }

        void Work(int hours);
    }
}
