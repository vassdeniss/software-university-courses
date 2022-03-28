namespace L02.RPG
{
    public interface ITarget
    {
        int Health { get; }

        int Experience { get; }

        void TakeAttack(int attackPoints);

        int GiveExperience();

        bool IsDead();
    }
}
