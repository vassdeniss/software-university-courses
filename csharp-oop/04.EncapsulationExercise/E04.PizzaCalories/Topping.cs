using System;

namespace E04.PizzaCalories
{
    enum ToppingType
    {
        MEAT,
        VEGGIES,
        CHEESE,
        SAUCE,
        INVALID
    }

    public class Topping
    {
        private const int BASE_CALORIES = 2;
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 50;

        private ToppingType topping;
        private int grams;
        private string givenTopping;

        public Topping(string topping, int grams)
        {
            givenTopping = topping;
            PizzaTopping = topping;
            Grams = grams;
        }

        public string PizzaTopping
        {
            get => topping.ToString();
            private set
            {
                ToppingType topping = GetTopping(value);
                if (topping == ToppingType.INVALID)
                {
                    throw new ArgumentException($"Cannot place {givenTopping} on top of your pizza.");
                }

                this.topping = topping;
            }
        }

        public int Grams
        {
            get => grams;
            private set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException($"{givenTopping} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double Calories =>
            grams *
            BASE_CALORIES *
            GetModifier(topping);

        private double GetModifier(ToppingType topping)
        {
            return topping switch
            {
                ToppingType.MEAT => 1.2,
                ToppingType.VEGGIES => 0.8,
                ToppingType.CHEESE => 1.1,
                ToppingType.SAUCE => 0.9,
                _ => 0
            };
        }

        private ToppingType GetTopping(string type)
        {
            return type.ToLower() switch
            {
                "meat" => ToppingType.MEAT,
                "veggies" => ToppingType.VEGGIES,
                "cheese" => ToppingType.CHEESE,
                "sauce" => ToppingType.SAUCE,
                _ => ToppingType.INVALID
            };
        }
    }
}
