namespace E01.Prototype
{
    internal class Program
    {
        static void Main()
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "Lettuce", "Tomato");
            menu["PB&J"] = new Sandwich("White", "Peanut Butter", "Jelly");
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss Cheese", "Lettuce", "Onion", "Tomato");

            Sandwich cloneBlt = menu["BLT"].Clone() as Sandwich;
            Sandwich clonePbj = menu["PB&J"].Clone() as Sandwich;
            Sandwich cloneTurkey = menu["Turkey"].Clone() as Sandwich;
        }
    }
}
