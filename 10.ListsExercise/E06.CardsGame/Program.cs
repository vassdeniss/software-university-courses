using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneHand = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            List<int> playerTwoHand = Console.ReadLine()
                .Split().Select(int.Parse).ToList();

            while (playerOneHand.Count > 0 && playerTwoHand.Count > 0)
            {
                int advantage = playerOneHand[0].CompareTo(playerTwoHand[0]);

                if (advantage > 0) // Player One Advantage
                {
                    playerOneHand.Add(playerOneHand[0]);
                    playerOneHand.Add(playerTwoHand[0]);
                    playerOneHand.RemoveAt(0);
                    playerTwoHand.RemoveAt(0);
                }
                else if (advantage < 0) // Player Two Advantage
                {
                    playerTwoHand.Add(playerTwoHand[0]);
                    playerTwoHand.Add(playerOneHand[0]);
                    playerTwoHand.RemoveAt(0);
                    playerOneHand.RemoveAt(0);
                }
                else
                {
                    playerOneHand.RemoveAt(0);
                    playerTwoHand.RemoveAt(0);
                }
            }

            List<int> winnerList = playerOneHand.Count > 0
                ? playerOneHand
                : playerTwoHand;
            string playerWon = playerOneHand.Count > 0
                ? "First"
                : "Second";
            int sum = 0;
            
            foreach (int n in winnerList) sum += n;
            Console.WriteLine($"{playerWon} player wins! Sum: {sum}");
        }
    }
}
