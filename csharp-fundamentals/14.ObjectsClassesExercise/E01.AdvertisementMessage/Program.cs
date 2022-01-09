using System;

namespace E01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases =
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events =
            {
                "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int rndTimes = int.Parse(Console.ReadLine());
            GenerateMessage(phrases, events, authors, cities, rndTimes);
        }

        static void GenerateMessage(string[] phrases, string[] events, string[] authors, string[] cities, int times)
        {
            Random rnd = new Random();
            for (int i = 0; i < times; i++)
            {
                string rndPhrase = phrases[rnd.Next(0, phrases.Length)];
                string rndEvent = events[rnd.Next(0, events.Length)];
                string rndAuthor = authors[rnd.Next(0, authors.Length)];
                string rndCity = cities[rnd.Next(0, cities.Length)];

                Console.WriteLine($"{rndPhrase} {rndEvent} {rndAuthor} - {rndCity}");
            }
        }
    }
}
