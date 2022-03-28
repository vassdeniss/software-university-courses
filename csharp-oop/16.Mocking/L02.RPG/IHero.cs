namespace L02.RPG
{
    public interface IHero
    {
        string Name { get; }

        int Experience { get; }

        IWeapon Weapon { get; }

        void Attack(ITarget target);
    }
}
