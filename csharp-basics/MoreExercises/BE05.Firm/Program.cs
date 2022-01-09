using System;

namespace BE05.Firm {
    class Program {
        static void Main(string[] args) {
            const double TRAINING_PERCENTAGE = 0.10;
            const int WORK_HOURS_IN_DAY = 8;
            const int OVERTIME_WORK_HOURS_IN_DAY = 2;
            int neededHours = int.Parse(Console.ReadLine()); 
            int avaliableDays = int.Parse(Console.ReadLine()); 
            int workersInOvertime = int.Parse(Console.ReadLine());

            double avaliableHoursMinusTraining = (avaliableDays - (avaliableDays * TRAINING_PERCENTAGE)) * WORK_HOURS_IN_DAY;
            int overtimeAvaliableHours = (workersInOvertime * OVERTIME_WORK_HOURS_IN_DAY) * avaliableDays;
            double totalHours = Math.Floor(avaliableHoursMinusTraining + overtimeAvaliableHours);

            if (totalHours >= neededHours) {
                Console.WriteLine($"Yes!{totalHours - neededHours} hours left.");
            } else {
                Console.WriteLine($"Not enough time!{neededHours - totalHours} hours needed.");
            }
        }
    }
}
