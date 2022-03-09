namespace E03.Raiding.Models
{
    public abstract class Fighter : BaseHero
    {
        public Fighter(string name) : base(name) { }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
