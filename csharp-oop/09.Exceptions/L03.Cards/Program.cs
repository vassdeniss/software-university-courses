using System;
using System.Collections.Generic;
using System.Linq;

namespace L03.Cards
{
    class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                string[] validValues = { "J", "Q", "K", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

                if (!validValues.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            private set
            {
                string[] validValues = { "S", "H", "D", "C" };

                if (!validValues.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = value;
            }
        }

        public override string ToString()
        {
            string emblem = suit switch
            {
                "S" => "\u2660",
                "H" => "\u2665",
                "D" => "\u2666",
                "C" => "\u2663",
                _ => null
            };

            return $"[{face}{emblem}]";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cards = Console.ReadLine().Split(", ");

            List<Card> validCards = new List<Card>();
            foreach (string currCard in cards)
            {
                string[] cardInfo = currCard.Split();
                string face = cardInfo[0];
                string suit = cardInfo[1];

                Card card;
                try
                {
                    card = new Card(face, suit);
                    validCards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", validCards));
        }
    }
}
