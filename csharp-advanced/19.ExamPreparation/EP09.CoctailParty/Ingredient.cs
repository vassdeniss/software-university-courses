
namespace CocktailParty
{
    using System.Text;
    
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; private set; }
        public int Alcohol { get; private set; }
        public int Quantity { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.AppendLine($"Alcohol: {Alcohol}");

            return sb.ToString().TrimEnd();
        }
    }
}
