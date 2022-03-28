namespace L02.RPG
{
    public class Hero : IHero
    {
        private string name;
        private int experience;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            this.name = name;
            this.weapon = weapon;

            experience = 0;
        }

        public string Name => name;

        public int Experience => experience;

        public IWeapon Weapon => weapon;

        public void Attack(ITarget target)
        {
            weapon.Attack(target);

            if (target.IsDead())
            {
                experience += target.GiveExperience();
            }
        }
    }
}
