namespace DefiningClasses
{
    public class Pokémon
    {
        public Pokémon(string name, string element, int health)
        {
            Name = name;
            Element = element;
            Health = health;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
