using System;

namespace E04.TrainTheTrainers {
    class Program {
        static void Main(string[] args) {
            int judgeCount = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            int gradeCounter = 0;
            double presentationTotalGrades = 0.0;

            while (presentationName != "Finish") {
                double totalGrade = 0.0;

                for (int i = 0; i < judgeCount; i++) {
                    double grade = double.Parse(Console.ReadLine());
                    totalGrade += grade;
                    presentationTotalGrades += grade;
                    gradeCounter++;
                }

                double averageGrade = totalGrade / judgeCount;
                
                Console.WriteLine($"{presentationName} - {averageGrade:f2}.");

                presentationName = Console.ReadLine();
            }

            double totalAvetageGrade = presentationTotalGrades / gradeCounter;

            Console.WriteLine($"Student's final assessment is {totalAvetageGrade:f2}.");
        }
    }
}
