namespace L02.RPG
{
    public interface IWeapon
    {
        int AttackPoints { get; }

        int DurabilityPoints { get; }

        void Attack(ITarget target);
    }
}
