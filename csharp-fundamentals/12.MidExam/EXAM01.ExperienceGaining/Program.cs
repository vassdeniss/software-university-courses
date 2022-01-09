using System;

namespace EXAM01.ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            int expNeeded = int.Parse(Console.ReadLine());
            int battlesQty = int.Parse(Console.ReadLine());

            int battleCount = 0;
            double totalExp = 0;
            for (int i = 1; i <= battlesQty; i++)
            {
                battleCount++;
                int gainedExp = int.Parse(Console.ReadLine());
                totalExp += gainedExp;
                if (i % 3 == 0) totalExp += gainedExp * 0.15;
                if (i % 5 == 0) totalExp -= gainedExp * 0.10;
                if (i % 15 == 0) totalExp += gainedExp * 0.05;
                if (totalExp >= expNeeded) break;
            }

            if (totalExp >= expNeeded)
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            else
                Console.WriteLine($"Player was not able to collect the needed experience, {expNeeded - totalExp:f2} more needed.");
        }
    }
}
