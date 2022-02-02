using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer()
        {
            Badges = 0;
            Pokémons = new List<Pokémon>();
        }

        public Trainer(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokémon> Pokémons { get; set; }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokémons.Count}";
        }
    }
}
