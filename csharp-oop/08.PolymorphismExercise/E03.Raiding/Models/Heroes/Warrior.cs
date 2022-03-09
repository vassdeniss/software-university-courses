namespace E03.Raiding.Models.Heroes
{
    public class Warrior : Fighter
    {
        public Warrior(string name) : base(name) { }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{base.CastAbility()}";
        }
    }
}
