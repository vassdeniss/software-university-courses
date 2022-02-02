using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public static class TrainerUtils
    {
        private static HashSet<Trainer> trainers = new HashSet<Trainer>();

        public static void AddTrainer(Trainer trainer)
        {
            Trainer findTrainer = trainers.FirstOrDefault(x => x.Name == trainer.Name);
            if (findTrainer == null) trainers.Add(trainer);
        }

        public static void AddPokémon(Trainer trainer, Pokémon pokémon)
        {
            Trainer findTrainer = trainers.FirstOrDefault(x => x.Name == trainer.Name);
            if (findTrainer != null) findTrainer.Pokémons.Add(pokémon);
        }

        public static void AddBadges(string element)
        {
            foreach (Trainer trainer in trainers)
            {
                Pokémon pokémon = trainer.Pokémons.FirstOrDefault(x => x.Element == element);

                if (pokémon != null)
                {
                    trainer.Badges++;
                    continue;
                }

                trainer.Pokémons.ForEach(x => x.Health -= 10);
                List<Pokémon> fainted = trainer.Pokémons.Where(x => x.Health <= 0).ToList();
                fainted.ForEach(x => trainer.Pokémons.Remove(x));
            }
        }

        public static void PrintTrainers()
        {
            foreach (Trainer trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
