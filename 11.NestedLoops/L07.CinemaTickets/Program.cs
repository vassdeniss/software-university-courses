using System;

namespace L07.CinemaTickets {
    class Program {
        static void Main(string[] args) {
            string movie = Console.ReadLine();
            double boughtTickets = 0.0;
            int studentTickets = 0;
            int kidTickets = 0;
            int standardTickets = 0;


            while (movie != "Finish") {
                int avaliableSeats = int.Parse(Console.ReadLine()); 
                string ticketType = Console.ReadLine();
                double seatedPeople = 0.0;

                while (ticketType != "End") {
                    switch (ticketType) {
                        case "standard": standardTickets++; break;
                        case "student": studentTickets++; break;
                        case "kid": kidTickets++; break;
                    }

                    boughtTickets++;
                    seatedPeople++;

                    if (seatedPeople >= avaliableSeats) { break; }
                    ticketType = Console.ReadLine();
                }

                double hallFullPercent = (seatedPeople / avaliableSeats) * 100;

                Console.WriteLine($"{movie} - {hallFullPercent:f2}% full.");
                movie = Console.ReadLine();
            }

            double studentTicketPercent = (studentTickets / boughtTickets) * 100;
            double standardTicketPercent = (standardTickets / boughtTickets) * 100;
            double kidTicketPercent = (kidTickets / boughtTickets) * 100;

            Console.WriteLine($"Total tickets: {boughtTickets}");
            Console.WriteLine($"{studentTicketPercent:f2}% student tickets.");
            Console.WriteLine($"{standardTicketPercent:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketPercent:f2}% kids tickets.");
        }
    }
}
