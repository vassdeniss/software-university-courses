using System;

namespace E07.HotelRoom {
    class Program {
        static void Main(string[] args) {
            const double MAY_OCTOMBER_STUDIO = 50;
            const double MAY_OCTOMBER_APARTMENT = 65;
            const double JUNE_SEPTEMBER_STUDIO = 75.20;
            const double JUNE_SEPTEMBER_APARTMENT = 68.70;
            const double JULY_AUGUST_STUDIO = 76;
            const double JULY_AUGUST_APARTMENT = 77;

            string month = Console.ReadLine();
            int stayPeriod = int.Parse(Console.ReadLine());

            double totalStudio = 0.0;
            double totalApartment = 0.0;

            switch (month) {
                case "May":
                case "October":
                    totalStudio += stayPeriod * MAY_OCTOMBER_STUDIO;
                    totalApartment += stayPeriod * MAY_OCTOMBER_APARTMENT;
                    if (stayPeriod > 14) {
                        totalStudio *= 0.7;
                        totalApartment *= 0.9;
                    } else if (stayPeriod > 7) {
                        totalStudio *= 0.95;
                    }
                    break;
                case "June":
                case "September":
                    totalStudio += stayPeriod * JUNE_SEPTEMBER_STUDIO;
                    totalApartment += stayPeriod * JUNE_SEPTEMBER_APARTMENT;
                    if (stayPeriod > 14) {
                        totalStudio *= 0.8;
                        totalApartment *= 0.9;
                    }
                    break;
                case "July":
                case "August":
                    totalStudio += stayPeriod * JULY_AUGUST_STUDIO;
                    totalApartment += stayPeriod * JULY_AUGUST_APARTMENT;
                    if (stayPeriod > 14) {
                        totalApartment *= 0.9;
                    }
                    break;
            }


            Console.WriteLine($"Apartment: {totalApartment:f2} lv.");
            Console.WriteLine($"Studio: {totalStudio:f2} lv.");
        }
    }
}
