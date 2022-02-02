using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input.Split();
                string trainerName = data[0];
                string pokémonName = data[1];
                string pokémonElement = data[2];
                int pokémonHealth = int.Parse(data[3]);

                Trainer trainer = new Trainer(trainerName);
                Pokémon pokémon = new Pokémon(pokémonName, pokémonElement, pokémonHealth);

                TrainerUtils.AddTrainer(trainer);
                TrainerUtils.AddPokémon(trainer, pokémon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string element = input;
                TrainerUtils.AddBadges(element);
            }

            TrainerUtils.PrintTrainers();
        }
    }
}
