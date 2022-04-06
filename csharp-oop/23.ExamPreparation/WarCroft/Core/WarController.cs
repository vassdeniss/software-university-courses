using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> party; 
		private readonly Stack<Item> items; 

		public WarController()
		{
			party = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType != nameof(Priest) && characterType != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			Type type = Type.GetType($"WarCroft.Entities.Characters.{characterType}");
			Character instance = Activator.CreateInstance(type, new object[] { name }) as Character;

			party.Add(instance);
			
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemType = args[0];

			if (itemType != nameof(HealthPotion) && itemType != nameof(FirePotion))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
			}

			Type type = Type.GetType($"WarCroft.Entities.Items.{itemType}");
			Item instance = Activator.CreateInstance(type) as Item;

			items.Push(instance);
			
			return string.Format(SuccessMessages.AddItemToPool, itemType);
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];

			Character character = party.FirstOrDefault(x => x.Name == name);
			
			if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

			if (items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = items.Pop();
			character.Bag.AddItem(item);
			
			return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = party.FirstOrDefault(x => x.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			item.AffectCharacter(character);

			return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			foreach (Character character in party
				.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health))
			{
				sb.AppendLine(character.ToString());
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			Character attacker = party.FirstOrDefault(x => x.Name == args[0]);
			if (attacker == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

			Character receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			if (!typeof(IAttacker).IsAssignableFrom(attacker.GetType()))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			}

			IAttacker castedAttacker = attacker as IAttacker;
			castedAttacker.Attack(receiver);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(
				$"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if (!receiver.IsAlive)
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			Character healer = party.FirstOrDefault(x => x.Name == args[0]);
			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}

			Character receiver = party.FirstOrDefault(x => x.Name == args[1]);
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			if (!typeof(IHealer).IsAssignableFrom(healer.GetType()))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			IHealer castedHealer = healer as IHealer;
			castedHealer.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
