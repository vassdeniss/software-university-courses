using System;

namespace ProjectCreation {
    class Program {
        static void Main(string[] args) {
            string name = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());
            int time = projectNumber * 3;
            Console.WriteLine($"The architect {name} will need {time} hours to complete {projectNumber} project/s.");
        }
    }
}
