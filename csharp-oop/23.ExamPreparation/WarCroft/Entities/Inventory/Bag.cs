using System;
using System.Collections.Generic;
using System.Linq;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;
        private int capacity = 100;

        public Bag(int capacity)
        {
            items = new List<Item>();

            Capacity = capacity;
        }

        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public int Load => items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);
            return item;
        }
    }
}
