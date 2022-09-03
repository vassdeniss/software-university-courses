using System.Collections.Generic;

namespace _01.RoyaleArena
{
    public interface IArena : IEnumerable<BattleCard>
    {
        void Add(BattleCard card);

        bool Contains(BattleCard card);

        int Count { get; }

        void ChangeCardType(int id, CardType type);

        BattleCard GetById(int id);

        void RemoveById(int id);

        IEnumerable<BattleCard> GetByCardType(CardType type);

        IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi);

        IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage);

        IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name);

        IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi);

        IEnumerable<BattleCard> FindFirstLeastSwag(int n);

        IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi);
    }
}
