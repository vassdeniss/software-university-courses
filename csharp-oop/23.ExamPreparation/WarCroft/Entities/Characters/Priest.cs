using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double DEFAULT_HEALTH = 50;
        private const double DEFAULT_ARMOR = 25;
        private const double DEFAULT_POINTS = 40;

        public Priest(string name)
            : base(name, DEFAULT_HEALTH, DEFAULT_ARMOR, DEFAULT_POINTS, new Backpack()) { }

        public void Heal(Character character)
        {
            EnsureAlive();

            character.RecieveHealing(AbilityPoints);
        }
    }
}
