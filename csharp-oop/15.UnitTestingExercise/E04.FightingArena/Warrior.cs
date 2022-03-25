using System;

namespace FightingArena
{
    public class Warrior
    {
        private const int MIN_ATTACK_HP = 30;

        private string name;
        private int damage;
        private int hp;

        public Warrior(string name, int damage, int hp)
        {
            Name = name;
            Damage = damage;
            HP = hp;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or whitespace!");
                }

                name = value;
            }
        }

        public int Damage
        {
            get => damage;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Damage value should be positive!");
                }

                damage = value;
            }
        }

        public int HP
        {
            get => hp;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HP should not be negative!");
                }

                hp = value;
            }
        }

        public void Attack(Warrior warrior)
        {
            if (HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            }

            if (warrior.HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
            }

            if (HP < warrior.Damage)
            {
                throw new InvalidOperationException($"You are trying to attack too strong enemy");
            }

            HP -= warrior.Damage;

            if (Damage > warrior.HP)
            {
                warrior.HP = 0;
            }
            else
            {
                warrior.HP -= Damage;
            }
        }
    }
}
