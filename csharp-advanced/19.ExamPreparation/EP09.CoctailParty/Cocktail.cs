namespace CocktailParty
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.Contains(ingredient) 
                || Ingredients.Count >= Capacity 
                || Ingredients.Sum(x => x.Alcohol) >= MaxAlcoholLevel)
            {
                return;
            }

            Ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient == null) return false;

            Ingredients.Remove(ingredient);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).ToList()[0];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            Ingredients.ForEach(x =>
            {
                sb.AppendLine($"Ingredient: {x.Name}");
                sb.AppendLine($"Quantity: {x.Quantity}");
                sb.AppendLine($"Alcohol: {x.Alcohol}");
            });

            return sb.ToString().TrimEnd();
        }
    }
}
