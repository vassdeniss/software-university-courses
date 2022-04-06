using System;

using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double DEFAULT_HEALTH = 100;
        private const double DEFAULT_ARMOR = 50;
        private const double DEFAULT_POINTS = 40;

        public Warrior(string name) 
            : base(name, DEFAULT_HEALTH, DEFAULT_ARMOR, DEFAULT_POINTS, new Satchel()) { }

        public void Attack(Character character)
        {
            EnsureAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}
