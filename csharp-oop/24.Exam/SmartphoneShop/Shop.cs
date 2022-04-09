using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartphoneShop
{
    public class Shop
    {
        private readonly List<Smartphone> phones;
        private int capacity;

        public Shop(int capacity)
        {
            phones = new List<Smartphone>();
            Capacity = capacity;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity.");
                }

                capacity = value;
            }
        }

        public int Count => phones.Count;

        public void Add(Smartphone smartPhone)
        {
            if (phones.Any(x => x.ModelName == smartPhone.ModelName))
            {
                throw new InvalidOperationException($"The phone model {smartPhone.ModelName} already exist.");
            }
            else if (phones.Count == capacity)
            {
                throw new InvalidOperationException("The shop is full.");
            }

            phones.Add(smartPhone);
        }

        public void Remove(string modelName)
        {
            Smartphone currentPhone = phones.FirstOrDefault(x => x.ModelName == modelName);

            if (currentPhone == null)
            {
                throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");
            }

            phones.Remove(currentPhone);
        }

        public void TestPhone(string modelName, int batteryUsage)
        {
            Smartphone currentPhone = phones.FirstOrDefault(x => x.ModelName == modelName);

            if (currentPhone == null)
            {
                throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");
            }
            else if (currentPhone.CurrentBateryCharge < batteryUsage)
            {
                throw new InvalidOperationException($"The phone model {currentPhone.ModelName} is low on batery.");
            }

            currentPhone.CurrentBateryCharge -= batteryUsage;
        }

        public void ChargePhone(string modelName)
        {
            Smartphone currentPhone = phones.FirstOrDefault(x => x.ModelName == modelName);

            if (currentPhone == null)
            {
                throw new InvalidOperationException($"The phone model {modelName} doesn't exist.");
            }

            currentPhone.CurrentBateryCharge = currentPhone.MaximumBatteryCharge;
        }
    }
}
