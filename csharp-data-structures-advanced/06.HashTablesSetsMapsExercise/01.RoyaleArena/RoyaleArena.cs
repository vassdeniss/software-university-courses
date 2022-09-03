using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.RoyaleArena
{
    public class RoyaleArena : IArena
    {
        private readonly Dictionary<int, BattleCard> cards;

        public RoyaleArena()
        {
            this.cards = new Dictionary<int, BattleCard>();
        }

        public void Add(BattleCard card)
        {
            this.cards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return this.cards.ContainsKey(card.Id);
        }

        public int Count => this.cards.Count;

        public void ChangeCardType(int id, CardType type)
        {
            if (!this.cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.cards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            if (!this.cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.cards[id];
        }

        public void RemoveById(int id)
        {
            if (!this.cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.cards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Type == type)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            if (!cards.Any())
            {
                throw new InvalidOperationException();
            }

            return cards;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Type == type && c.Damage > lo && c.Damage < hi)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            if (!cards.Any())
            {
                throw new InvalidOperationException();
            }

            return cards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Type == type && c.Damage <= damage)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            if (!cards.Any())
            {
                throw new InvalidOperationException();
            }

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Name == name)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);

            if (!cards.Any())
            {
                throw new InvalidOperationException();
            }

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Name == name && c.Swag > lo && c.Swag < hi)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);

            if (!cards.Any())
            {
                throw new InvalidOperationException();
            }

            return cards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.cards.Count)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<BattleCard> cards = this.cards.Values
                .OrderBy(c => c.Swag)
                .ThenBy(c => c.Id)
                .Take(n);

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            IOrderedEnumerable<BattleCard> cards = this.cards.Values
                .Where(c => c.Swag > lo && c.Swag < hi)
                .OrderBy(c => c.Swag);

            if (!cards.Any())
            {
                return Enumerable.Empty<BattleCard>();
            }

            return cards;
        }

        public IEnumerator<BattleCard> GetEnumerator()
        { 
            foreach (BattleCard card in this.cards.Values)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
