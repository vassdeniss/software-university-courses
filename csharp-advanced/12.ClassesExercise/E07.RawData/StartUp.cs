using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string[] data = Console.ReadLine().Split();
                string model = data[0];
                int speed = int.Parse(data[1]);
                int power = int.Parse(data[2]);
                int weight = int.Parse(data[3]);
                string type = data[4];

                int idx = 0;
                Tire[] tires = new Tire[4];
                for (int j = 5; j <= 12; j += 2)
                {
                    double pressure = double.Parse(data[j]);
                    int age = int.Parse(data[j + 1]);

                    tires[idx++] = new Tire(age, pressure);
                }

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weight);

                CarUtils.AddCar(new Car(model, engine, cargo, tires));
            }

            string filterType = Console.ReadLine();
            CarUtils.FilterCars(filterType);
            CarUtils.PrintCars();
        }
    }
}
