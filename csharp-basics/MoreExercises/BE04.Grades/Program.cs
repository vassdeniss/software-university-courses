using System;

namespace BE04.Grades {
    class Program {
        static void Main(string[] args) {
            int studentQty = int.Parse(Console.ReadLine());

            double totalGrades = 0;
            double topStudents = 0;
            double betweenFourStudents = 0;
            double averageStudents = 0;
            double failedStudents = 0;

            for (int i = 0; i < studentQty; i++) {
                double grade = double.Parse(Console.ReadLine());
                totalGrades += grade;
                if (grade >= 5.00) { topStudents++; }
                else if (grade >= 4.00 && grade <= 4.99) { betweenFourStudents++; }
                else if (grade >= 3.00 && grade <= 3.99) { averageStudents++; }
                else if (grade < 3.00) { failedStudents++; }
            }

            double topStudentsPercent = (topStudents / studentQty) * 100;
            double betweenFourStudentsPercent = (betweenFourStudents / studentQty) * 100;
            double averageStudentsPercent = (averageStudents / studentQty) * 100;
            double failedStudentsPercent = (failedStudents / studentQty) * 100;
            double average = totalGrades / studentQty;

            Console.WriteLine($"Top students: {topStudentsPercent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {betweenFourStudentsPercent:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {averageStudentsPercent:f2}%");
            Console.WriteLine($"Fail: {failedStudentsPercent:f2}%");
            Console.WriteLine($"Average: {average:f2}");
        }
    }
}
