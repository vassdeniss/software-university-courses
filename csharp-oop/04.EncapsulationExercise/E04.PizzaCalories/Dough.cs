using System;

namespace E04.PizzaCalories
{
    enum FlourType
    {
        WHITE,
        WHOLEGRAIN,
        INVALID
    }

    enum BakingTechnique
    {
        CRISPY,
        CHEWY,
        HOMEMADE,
        INVALID
    }

    public class Dough
    {
        private const int BASE_CALORIES = 2;
        private const int MIN_GRAMS = 1;
        private const int MAX_GRAMS = 200;

        private FlourType flour;
        private BakingTechnique technique;
        private int grams;

        public Dough(string flour, string technique, int grams)
        {
            Flour = flour;
            Technique = technique;
            Grams = grams;
        }

        public string Flour
        {
            get => flour.ToString();
            private set
            {
                FlourType flour = GetFlour(value);
                if (flour == FlourType.INVALID)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = flour;
            }
        }

        public string Technique
        {
            get => technique.ToString();
            private set
            {
                BakingTechnique technique = GetBakingTechnique(value);
                if (technique == BakingTechnique.INVALID)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = technique;
            }
        }

        public int Grams
        {
            get => grams;
            private set
            {
                if (value < MIN_GRAMS || value > MAX_GRAMS)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double Calories =>
            grams *
            BASE_CALORIES *
            GetFlourModifier(flour) *
            GetTechniqueModifier(technique);

        private double GetTechniqueModifier(BakingTechnique technique)
        {
            return technique switch
            {
                BakingTechnique.CRISPY => 0.9,
                BakingTechnique.CHEWY => 1.1,
                BakingTechnique.HOMEMADE => 1.0,
                _ => 0
            };
        }

        private double GetFlourModifier(FlourType flour)
        {
            return flour switch
            {
                FlourType.WHITE => 1.5,
                FlourType.WHOLEGRAIN => 1.0,
                _ => 0
            };
        }

        private FlourType GetFlour(string type)
        {
            return type.ToLower() switch
            {
                "white" => FlourType.WHITE,
                "wholegrain" => FlourType.WHOLEGRAIN,
                _ => FlourType.INVALID
            };
        }

        private BakingTechnique GetBakingTechnique(string type)
        {
            return type.ToLower() switch
            {
                "crispy" => BakingTechnique.CRISPY,
                "chewy" => BakingTechnique.CHEWY,
                "homemade" => BakingTechnique.HOMEMADE,
                _ => BakingTechnique.INVALID
            };
        }
    }
}
