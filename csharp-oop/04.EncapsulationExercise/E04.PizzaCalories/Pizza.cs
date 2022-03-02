using System;
using System.Collections.Generic;

namespace E04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        private Pizza()
        {
            toppings = new List<Topping>();
        }

        public Pizza(string name) : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings => toppings.AsReadOnly();

        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            double calories = dough.Calories;
            toppings.ForEach(x => calories += x.Calories);
            return $"{name} - {calories:f2} Calories.";
        }
    }
}
