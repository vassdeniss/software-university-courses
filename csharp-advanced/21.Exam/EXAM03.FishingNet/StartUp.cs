using System;

namespace FishingNet
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository (Net)
            Net net = new Net("cast net", 10);

            // Initialize entity
            Fish fishOne = new Fish("salmon", 44.25, 941.15);
            Fish fishTwo = new Fish("catfish", 105.25, 2100.15);
            Fish fishThree = new Fish("bass", 25.25, 321.15);

            // Add Fish
            Console.WriteLine(net.AddFish(fishOne));  // Successfully added salmon to the fishing net.
            Console.WriteLine(net.AddFish(fishTwo));  // Successfully added carfish to the fishing net.
            Console.WriteLine(net.AddFish(fishThree));// Successfully added bass to the fishing net.
            Console.WriteLine(net.Count); // 3

            foreach (var fish in net.Fish)
            {
                Console.WriteLine(fish.ToString());
                // There is a salmon, 44.25 cm. long, and 941.15 gr. in weight.
                // There is a carfish, 105.25 cm. long, and 2100.15 gr. in weight.
                // There is a bass, 25.25 cm. long, and 321.15 gr. in weight.
            }

            // Remove Fish
            Console.WriteLine(net.ReleaseFish(321.15));  // True
            Console.WriteLine(net.Count); // 2

            Fish fishFour = new Fish("mullet", 15.21, 150.33);
            Fish fishFive = new Fish("barbel", 21.33, 190.14);
            Fish fishSix = new Fish("trout", 38.35, 357.41);

            // Add Fish
            Console.WriteLine(net.AddFish(fishFour));  // Successfully added мullet to the fishing net.
            Console.WriteLine(net.AddFish(fishFive));  // Successfully added barbel to the fishing net.
            Console.WriteLine(net.AddFish(fishSix));   // Successfully added trout to the fishing net.

            // GetFish
            Console.WriteLine(net.GetFish("trout"));
            // There is a trout, 38.35 cm. long, and 357.41 gr. in weight.
            // GetBiggestFish
            Console.WriteLine(net.GetBiggestFish());
            // There is a carfish, 105.25 cm. long, and 2100.15 gr. in weight.

            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(net.Report());
            /*
            Into the cast net:
            There is a catfish, 105.25 cm. long, and 2100.15 gr. in weight.
            There is a salmon, 44.25 cm. long, and 941.15 gr. in weight.
            There is a trout, 38.35 cm. long, and 357.41 gr. in weight.
            There is a barbel, 21.33 cm. long, and 190.14 gr. in weight.
            There is a mullet, 15.21 cm. long, and 150.33 gr. in weight.
            */
        }
    }
}
