using E04.BorderControl.Contracts;

namespace E04.BorderControl.Models
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
