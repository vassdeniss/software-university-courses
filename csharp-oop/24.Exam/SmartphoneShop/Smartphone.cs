namespace SmartphoneShop
{
    public class Smartphone
    {
        public Smartphone(string modelName, int maximumBatteryCharge)
        {
            ModelName = modelName;
            MaximumBatteryCharge = maximumBatteryCharge;
            CurrentBateryCharge = maximumBatteryCharge;
        }

        public string ModelName { get; set; }

        public int CurrentBateryCharge { get; set; }

        public int MaximumBatteryCharge { get; }
    }
}
