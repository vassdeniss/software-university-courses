using System;

namespace E02.Composite
{
    internal class Program
    {
        static void Main()
        {
            GiftComposite box = new GiftComposite("Big Gift Box", 0);
            GiftComposite consoleBox = new GiftComposite("Box of Consoles", 0);
            
            GiftSingle phone = new GiftSingle("IPhone 13 Pro Max", 1500);
            GiftSingle @switch = new GiftSingle("Nintendo Switch", 600);
            GiftSingle playstation = new GiftSingle("Sony Playstation 5", 1000);

            consoleBox.Add(@switch);
            consoleBox.Add(playstation);

            box.Add(phone);
            box.Add(consoleBox);

            Console.WriteLine($"Total price of this composite present is: {box.CalculatePrice()}");
        }
    }
}
