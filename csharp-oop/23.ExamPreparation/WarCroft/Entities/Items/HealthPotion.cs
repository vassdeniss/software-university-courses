using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    internal class HealthPotion : Item
    {
        private const int POTION_WEIGHT = 5;

        public HealthPotion() : base(POTION_WEIGHT) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}
