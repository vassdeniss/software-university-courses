using System;

namespace EXAM02.MaidenParty {
    class Program {
        static void Main(string[] args) {
            const double LOVE_LETTER = 0.6;
            const double WAX_ROSE = 7.2;
            const double KEYCHAIN = 3.6;
            const double CARICATURE = 18.2;
            const double LUCKY_SURPRISE = 22;

            double total = 0.0;
            int totalItems = 0;

            double girlPartyTotal = double.Parse(Console.ReadLine());
            int loveLetterQty = int.Parse(Console.ReadLine());
            int waxRoseQty = int.Parse(Console.ReadLine());
            int keychainQty = int.Parse(Console.ReadLine());
            int caricatureQty = int.Parse(Console.ReadLine());
            int luckySurpriseQty = int.Parse(Console.ReadLine());

            total += loveLetterQty * LOVE_LETTER
                + waxRoseQty * WAX_ROSE
                + keychainQty * KEYCHAIN
                + caricatureQty * CARICATURE
                + luckySurpriseQty * LUCKY_SURPRISE;

            totalItems += loveLetterQty + waxRoseQty
                + keychainQty + caricatureQty + luckySurpriseQty;

            if (totalItems >= 25) {
                total *= 0.65;
            }

            total *= 0.9;

            if (total >= girlPartyTotal) {
                Console.WriteLine($"Yes! {(total - girlPartyTotal):f2} lv left.");
            } else {
                Console.WriteLine($"Not enough money! {(girlPartyTotal - total):f2} lv needed.");
            }
        }
    }
}
