using System;

namespace E09.VolleyBall {
    class Program {
        static void Main(string[] args) {
            const double WEEKENDS_IN_AN_YEAR = 48;
            string yearType = Console.ReadLine();
            int holidayNumber = int.Parse(Console.ReadLine()); 
            int weekedTravel = int.Parse(Console.ReadLine());

            double weekendsInSofia = WEEKENDS_IN_AN_YEAR - weekedTravel;
            double matchesInSofia = weekendsInSofia * 3.0 / 4.0;
            double matchesInHome = weekedTravel;
            double matchesOnHolidays = holidayNumber * 2.0 / 3.0;
            double totalMatches = matchesInSofia + matchesInHome + matchesOnHolidays;
            if (yearType == "leap") { totalMatches *= 1.15; }

            Console.WriteLine(Math.Floor(totalMatches));
        }
    }
}
