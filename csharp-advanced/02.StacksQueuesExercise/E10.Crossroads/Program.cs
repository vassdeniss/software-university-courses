using System;
using System.Collections.Generic;

namespace E10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int passed = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int green = greenLight;
                while (green > 0 && cars.Count > 0)
                {
                    string car = cars.Dequeue();
                    int carLength = car.Length;
                    if (green - carLength >= 0)
                    {
                        green -= carLength;
                        passed++;
                        if (cars.Count == 0 || green == 0) break;
                        else continue;
                    }

                    if (green - carLength < 0)
                    {
                        if (carLength - green > freeWindow)
                        {
                            int left = carLength - green - freeWindow;
                            string hit = car[^left..];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {hit[0]}.");
                            return;
                        }

                        green -= carLength;
                        passed++;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");
        }
    }
}
