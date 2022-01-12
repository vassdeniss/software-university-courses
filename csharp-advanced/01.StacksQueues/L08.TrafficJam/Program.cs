using System;
using System.Collections.Generic;

namespace L08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightPass = int.Parse(Console.ReadLine());

            Queue<string> traffic = new Queue<string>();
            string car = Console.ReadLine();
            int passedCars = 0;
            while (car != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < greenLightPass; i++)
                    {
                        try
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            passedCars++;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    car = Console.ReadLine();
                    continue;
                }

                traffic.Enqueue(car);
                car = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
