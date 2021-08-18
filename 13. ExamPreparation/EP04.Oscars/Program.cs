using System;

namespace EP04.Oscars {
    class Program {
        static void Main(string[] args) {
            string actorNmae = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int juryQty = int.Parse(Console.ReadLine());

            for (int i = 0; i < juryQty; i++) {
                if (academyPoints > 1250.5) { break; }
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                academyPoints += juryPoints * juryName.Length / 2;
            }

            if (academyPoints > 1250.5) {
                Console.WriteLine($"Congratulations, {actorNmae} got a nominee for leading role with {academyPoints:f1}!");
            } else {
                Console.WriteLine($"Sorry, {actorNmae} you need {(1250.5 - academyPoints):f1} more!");
            }
        }
    }
}
