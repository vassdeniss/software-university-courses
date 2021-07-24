using System;

namespace E08.OnTimeForTheExam {
    class Program {
        static void Main(string[] args) {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            // Right on the hour
            if (arrivalHour == examHour && arrivalMinutes == examMinutes) {
                Console.WriteLine("On time");
            }

            // 30 minutes or less early within the same hour
            else if (arrivalHour == examHour && arrivalMinutes < examMinutes && arrivalMinutes >= examMinutes - 30) {
                Console.WriteLine("On time");
                Console.WriteLine($"{examMinutes - arrivalMinutes} minutes before the start");
            }

            // 30 minutes or less early in a different hour
            else if (arrivalHour == examHour - 1 && arrivalMinutes > examMinutes && arrivalMinutes >= 30 && examMinutes <= 29) {
                Console.WriteLine("On time");
                Console.WriteLine($"{(60 - arrivalMinutes) + examMinutes} minutes before the start");
            }

            // Early within the same hour
            else if (arrivalHour == examHour && arrivalMinutes < (examMinutes - 30)) {
                Console.WriteLine("Early");
                Console.WriteLine($"{examMinutes - arrivalMinutes} minutes before the start");
            }

            // Early more than an hour
            else if (arrivalHour < examHour) {
                int totalMinutes = (60 - arrivalMinutes) + ((examHour - (arrivalHour + 1)) * 60) + examMinutes;
                int hour = totalMinutes / 60;
                int minutes = totalMinutes % 60;
                Console.WriteLine("Early");
                if (hour != 0) {
                    Console.WriteLine($"{hour}:{minutes:d2} hours before the start");
                } else {
                    Console.WriteLine($"{minutes} minutes before the start");
                }
                
            }

            // Late within the same hour
            else if (arrivalHour == examHour && arrivalMinutes > examMinutes) {
                Console.WriteLine("Late");
                Console.WriteLine($"{arrivalMinutes - examMinutes} minutes after the start");
            }

            // Late more than an hour
            else if (arrivalHour > examHour) {
                int totalMinutes = (60 - examMinutes) + ((arrivalHour - (examHour + 1)) * 60) + arrivalMinutes;
                int hour = totalMinutes / 60;
                int minutes = totalMinutes % 60;
                Console.WriteLine("Late");
                if (hour != 0) {
                    Console.WriteLine($"{hour}:{minutes:d2} hours after the start");
                } else {
                    Console.WriteLine($"{minutes} minutes after the start");
                }
            }
        }
    }
}
