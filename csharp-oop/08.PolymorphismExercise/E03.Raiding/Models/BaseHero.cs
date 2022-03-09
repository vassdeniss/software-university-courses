using E03.Raiding.Contracts;

namespace E03.Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract int Power { get; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name}";
        }
    }
}
