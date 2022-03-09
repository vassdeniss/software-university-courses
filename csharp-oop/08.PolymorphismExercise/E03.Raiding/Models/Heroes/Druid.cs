namespace E03.Raiding.Models.Heroes
{
    public class Druid : Healer
    {
        public Druid(string name) : base(name) { }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{base.CastAbility()}";
        }
    }
}
