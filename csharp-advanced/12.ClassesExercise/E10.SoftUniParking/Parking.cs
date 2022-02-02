using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new Dictionary<string, Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber)) 
                return "Car with that registration number, already exists!";
            
            if (cars.Count >= capacity) 
                return "Parking is full!";

            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registry)
        {
            if (!cars.ContainsKey(registry))
                return "Car with that registration number, doesn't exist!";

            cars.Remove(registry);
            return $"Successfully removed {registry}";
        }

        public Car GetCar(string registry)
        {
            return cars.FirstOrDefault(x => x.Key == registry).Value;
        }

        public void RemoveSetOfRegistrationNumber(List<string> numbers)
        {
            numbers.ForEach(x => cars.Remove(x));
        }

        public int Count => cars.Count;
    }
}
