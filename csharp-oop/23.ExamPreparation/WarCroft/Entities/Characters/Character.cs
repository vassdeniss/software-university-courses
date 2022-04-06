using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private IBag bag;

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealth;
            private set => baseHealth = value;
        }

        public double Health
        {
            get => health;
            set
            {
                health = value;

                if (health < 0)
                {
                    health = 0;
                }
                
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
        }

        public double BaseArmor
        {
            get => baseArmor;
            private set => baseArmor = value;
        }

        public double Armor
        {
            get => armor;
            private set
            {
                armor = value;

                if (armor < 0) armor = 0;
            }
        }

        public double AbilityPoints
        {
            get => abilityPoints;
            private set => abilityPoints = value;
        }

        public IBag Bag
        {
            get => bag;
            private set => bag = value;
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (hitPoints <= Armor)
            {
                Armor -= hitPoints;
            }
            else
            {
                Health -= hitPoints - Armor;
                Armor = 0;
            }

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void RecieveHealing(double amount)
        {
            EnsureAlive();

            Health += amount;
        }

        public override string ToString()
        {
            string deadOrAlive = IsAlive ? "Alive" : "Dead";

            return $"{Name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {deadOrAlive}";
        }
    }
}
