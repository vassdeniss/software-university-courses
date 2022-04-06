using System;

using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public abstract class Item
	{
		protected Item(int weight)
		{
			Weight = weight;
		}

		public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
