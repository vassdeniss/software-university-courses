using E05.BirthdayCelebrations.Contracts;

namespace E05.BirthdayCelebrations.Models
{
    public class Robot : IResident, IMachine
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }

        public string Model { get; private set; }

        public string ID { get; private set; }
    }
}
