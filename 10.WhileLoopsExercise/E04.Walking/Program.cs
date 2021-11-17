using System;

namespace E04.Walking {
    class Program {
        static void Main(string[] args) {
            const int STEP_GOAL = 10000;
            int totalSteps = 0;
            string input = Console.ReadLine();

            while (true) {
                if (totalSteps >= STEP_GOAL) {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{totalSteps - STEP_GOAL} steps over the goal!");
                    return;
                }

                if (input == "Going home") {
                    totalSteps += int.Parse(Console.ReadLine());
                    if (totalSteps >= STEP_GOAL) {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - STEP_GOAL} steps over the goal!");
                    } else {
                        Console.WriteLine($"{STEP_GOAL - totalSteps} more steps to reach goal.");
                    }
                    return;
                }

                totalSteps += int.Parse(input);
                input = Console.ReadLine();
            }
        }
    }
}
