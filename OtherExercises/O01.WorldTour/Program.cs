using System;

namespace O01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Travel")
            {
                string[] cmd = input.Split(':');
                if (cmd[0] == "Add Stop")
                {
                    int index = int.Parse(cmd[1]);
                    if (ValidIndex(index, stops.Length)) stops = stops.Insert(index, cmd[2]);
                    Console.WriteLine(stops);
                }
                else if (cmd[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);
                    if (ValidIndex(startIndex, stops.Length) && ValidIndex(endIndex, stops.Length))
                        stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(stops);
                }
                else if (cmd[0] == "Switch")
                {
                    if (stops.Contains(cmd[1])) stops = stops.Replace(cmd[1], cmd[2]);
                    Console.WriteLine(stops);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        static bool ValidIndex(int index, int length) => index <= length - 1 && index >= 0;
    }
}
