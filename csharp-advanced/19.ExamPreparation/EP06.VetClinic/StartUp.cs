namespace VetClinic
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Clinic clinic = new Clinic(20);
            Pet dog = new Pet("Ellias", 5, "Tim");
            Console.WriteLine(dog); // Ellias 5 (Tim)

            clinic.Add(dog);
            Console.WriteLine(clinic.Remove("Ellias")); // True
            Console.WriteLine(clinic.Remove("Pufa")); // False

            Pet cat = new Pet("Bella", 2, "Mia");
            Pet bunny = new Pet("Zak", 4, "Jon");
            clinic.Add(cat);
            clinic.Add(bunny);

            Pet oldestPet = clinic.GetOldestPet();
            Console.WriteLine(oldestPet); // Zak 4 (Jon)

            Pet pet = clinic.GetPet("Bella", "Mia");
            Console.WriteLine(pet); // Bella 2 (Mia)

            Console.WriteLine(clinic.Count); // 2

            Console.WriteLine(clinic.GetStatistics());
            // The clinic has the following patients:
            // Bella Mia
            // Zak Jon
        }
    }
}
