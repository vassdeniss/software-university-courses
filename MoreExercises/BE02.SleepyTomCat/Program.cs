using System;

namespace BE02.SleepyTomCat {
    class Program {
        static void Main(string[] args) {
            const int MINUTES_IN_YEAR = 30000;
            const int DAYS_IN_YEAR = 365;
            const int WORK_DAY_PLAY = 63;
            const int HOLIDAY_PLAY = 127;
            int holidays = int.Parse(Console.ReadLine());

            int workDays = DAYS_IN_YEAR - holidays;
            int totalPlayTime = (workDays * WORK_DAY_PLAY) + (holidays * HOLIDAY_PLAY);

            if (totalPlayTime > MINUTES_IN_YEAR) {
                int difference = totalPlayTime - MINUTES_IN_YEAR;
                int hours = difference / 60;
                int minutes = difference % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            } else {
                int difference = MINUTES_IN_YEAR - totalPlayTime;
                int hours = difference / 60;
                int minutes = difference % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }   
    }
}
