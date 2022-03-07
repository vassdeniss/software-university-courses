namespace Animals.Models
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood) { }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}\nDJAAF";
        }
    }
}
