using System;

namespace L08.Graduation {
    class Program {
        static void Main(string[] args) {
            string studentName = Console.ReadLine();
            int year = 1;
            int fails = 0;
            double averageGrade = 0.0;

            while (year <= 12) {
                double yearGrade = double.Parse(Console.ReadLine());
                averageGrade += yearGrade;
                if (yearGrade < 4) {
                    fails++;
                    if (fails > 1) {
                        Console.WriteLine($"{studentName} has been excluded at " +
                            $"{year} grade");
                        return;
                    }
                    continue;
                }
                year++;
            }

            averageGrade /= 12;

            Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
