using System;

namespace E02.ExamPreparation {
    class Program {
        static void Main(string[] args) {
            int maxBadGrades = int.Parse(Console.ReadLine());
            string problem = Console.ReadLine();
            string lastProblem = "";
            int badGrades = 0;
            int totalGrades = 0;
            double totalGradesNumber = 0.0;
            int totalProblems = 0;

            while (problem != "Enough") {
                int grade = int.Parse(Console.ReadLine());
                totalGrades++; totalProblems++;
                totalGradesNumber += grade;
                if (grade <= 4) { badGrades++; }
                if (badGrades == maxBadGrades) {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    return;
                }
                lastProblem = problem;
                problem = Console.ReadLine();
            }

            Console.WriteLine($"Average score: {(totalGradesNumber / totalGrades):f2}");
            Console.WriteLine($"Number of problems: {totalProblems}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
