using System;

namespace _01.RoyaleArena
{
    public class BattleCard : IComparable<BattleCard>
    {

        public BattleCard(int id, CardType type, string name, double damage, double swag) 
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Damage = damage;
            this.Swag = swag;
        }

        public int Id { get; set; }

        public CardType Type { get; set; }

        public string Name { get; set; }

        public double Damage { get; set; }

        public double Swag { get; set; }

        public int CompareTo(BattleCard other) 
        {
            int compare = other.Damage.CompareTo(this.Damage);

            if (compare == 0) 
            {
                compare = this.Id.CompareTo(other.Id);
            }

            return compare;
        }

        public override bool Equals(object other) 
        {
            if (this == other)
            {
                return true;
            }

            if (other == null || this.GetType().Name.CompareTo(other.GetType().Name) != 0)
            {
                return false;
            }

            BattleCard bc = (BattleCard)other;
            return this.Id == bc.Id &&
                   bc.Damage.Equals(this.Damage) &&
                   bc.Swag.Equals(this.Swag) &&
                   this.Type.Equals(bc.Type) &&
                   this.Name.Equals(bc.Name);
        }

        public override int GetHashCode() 
        {
            return this.Id;
        }
    }
}
