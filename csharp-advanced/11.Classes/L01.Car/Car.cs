namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}";
        }
    }
}
