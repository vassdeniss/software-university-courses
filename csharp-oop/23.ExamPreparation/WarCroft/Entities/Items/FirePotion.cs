using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int POTION_WEIGHT = 5;

        public FirePotion() : base(POTION_WEIGHT) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health < 0) character.IsAlive = false;
        }
    }
}
