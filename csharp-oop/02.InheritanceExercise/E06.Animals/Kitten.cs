using System;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KITTEN_GENDER = "Female";

        public Kitten(string name, int age) 
            : base(name, age, KITTEN_GENDER) { }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
