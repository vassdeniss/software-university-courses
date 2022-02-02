namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
