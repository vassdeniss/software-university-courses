using System;

namespace L02.RPG
{
    public class Axe : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public Axe(int attack, int durability)
        {
            attackPoints = attack;
            durabilityPoints = durability;
        }

        public int AttackPoints => attackPoints;

        public int DurabilityPoints => durabilityPoints;

        public void Attack(ITarget target)
        {
            if (durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(attackPoints);
            durabilityPoints -= 1;
        }
    }
}
