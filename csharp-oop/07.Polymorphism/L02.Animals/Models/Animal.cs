namespace Animals.Models
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; protected set; }

        public string FavouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouriteFood}";
        } 
    }
}
