using System;

namespace BE02.Hospital {
    class Program {
        static void Main(string[] args) {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;

            int treatedPatients = 0;
            int untreatedPatients = 0;
            int days = 1;

            for (int i = 1; i <= period; i++) {
                if (days % 3 == 0) {
                    if (untreatedPatients > treatedPatients) {
                        doctors++;
                    }
                }
                int patientQty = int.Parse(Console.ReadLine());
                if (patientQty > doctors) {
                    treatedPatients += doctors;
                    untreatedPatients += patientQty - doctors;
                } else { treatedPatients += patientQty; }
                days++;
            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
