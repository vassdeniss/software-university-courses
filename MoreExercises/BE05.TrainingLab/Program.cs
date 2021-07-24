using System;

namespace BE05.TrainingLab {
    class Program {
        static void Main(string[] args) {
            const double WORK_SPACE_W = 70;
            const double WORK_SPACE_H = 120;
            const double HALL_H = 100;
            const int LOST_WORK_SPACE = 3;

            double w = double.Parse(Console.ReadLine()) * 100;
            double h = double.Parse(Console.ReadLine()) * 100;

            double spaceH = (h - HALL_H) / WORK_SPACE_W;
            double spaceW = w / WORK_SPACE_H;

            int total = (int)spaceH * (int)spaceW - LOST_WORK_SPACE;
            Console.WriteLine(total);
        }
    }
}
