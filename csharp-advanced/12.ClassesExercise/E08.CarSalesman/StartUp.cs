using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineQty; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int power = int.Parse(data[1]);

                Engine engine = new Engine(model, power);
                GetOptionalInputEngine(data, engine);

                EngineUtils.AddEngine(engine);
            }

            int carQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < carQty; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                string engineString = data[1];
                Engine engine = EngineUtils.GetEngine(engineString);

                Car car = new Car(model, engine);
                GetOptionalInputCar(data, car);

                CarUtils.AddCar(car);
            }

            CarUtils.PrintCars();
        }

        private static void GetOptionalInputCar(string[] data, Car car)
        {
            if (data.Length == 4)
            {
                int weight = int.Parse(data[2]);
                string color = data[3];

                car.Weight = weight;
                car.Color = color;
            }
            else if (data.Length == 3)
            {
                bool isWeight = int.TryParse(data[2], out int weight);
                if (isWeight) car.Weight = weight;
                else car.Color = data[2];
            }
        }

        private static void GetOptionalInputEngine(string[] data, Engine engine)
        {
            if (data.Length == 4)
            {
                int displacement = int.Parse(data[2]);
                string efficiency = data[3];

                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
            }
            else if (data.Length == 3)
            {
                bool isDisplacement = int.TryParse(data[2], out int displacement);
                if (isDisplacement) engine.Displacement = displacement;
                else engine.Efficiency = data[2];
            }
        }
    }
}
