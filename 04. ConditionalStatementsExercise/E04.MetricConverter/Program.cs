using System;

namespace E04.MetricConverter {
    class Program {
        static void Main(string[] args) {
            double numberToConvert = double.Parse(Console.ReadLine());
            string inputMeasurement = Console.ReadLine();
            string outputMeasurement = Console.ReadLine();

            if (inputMeasurement == "m" && outputMeasurement == "m") { 
                Console.WriteLine($"{numberToConvert:f3}"); 
            } else if (inputMeasurement == "m" && outputMeasurement == "cm") {
                numberToConvert = numberToConvert * 100;
                Console.WriteLine($"{numberToConvert:f3}");
            } else if (inputMeasurement == "m" && outputMeasurement == "mm") {
                numberToConvert = numberToConvert * 1000;
                Console.WriteLine($"{numberToConvert:f3}");
            }

            if (inputMeasurement == "cm" && outputMeasurement == "m") {
                numberToConvert = numberToConvert / 100;
                Console.WriteLine($"{numberToConvert:f3}");
            } else if (inputMeasurement == "cm" && outputMeasurement == "cm") {
                Console.WriteLine($"{numberToConvert:f3}");
            } else if (inputMeasurement == "cm" && outputMeasurement == "mm") {
                numberToConvert = numberToConvert * 10;
                Console.WriteLine($"{numberToConvert:f3}");
            }
            
            if (inputMeasurement == "mm" && outputMeasurement == "m") {
                numberToConvert = numberToConvert / 1000;
                Console.WriteLine($"{numberToConvert:f3}");
            } else if (inputMeasurement == "mm" && outputMeasurement == "cm") {
                numberToConvert = numberToConvert / 10;
                Console.WriteLine(($"{numberToConvert:f3}"));
            } else if (inputMeasurement == "m," && outputMeasurement == "mm") {
                Console.WriteLine($"{numberToConvert:f3}");
            }
        }
    }
}
