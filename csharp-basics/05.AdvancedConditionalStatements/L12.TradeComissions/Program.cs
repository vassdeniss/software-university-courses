using System;

namespace L12.TradeComissions {
    class Program {
        static void Main(string[] args) {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double comission = 0.0;

            switch (city) {
                case "Sofia": 
                    if (sales >= 0 && sales <= 500) {
                        comission = sales * 0.05;
                    } else if (sales > 500 && sales <= 1000) {
                        comission = sales * 0.07;
                    } else if (sales > 1000 && sales <= 10000) {
                        comission = sales * 0.08;
                    } else if (sales > 10000) {
                        comission = sales * 0.12;
                    }
                    if (!(sales < 0)) { Console.WriteLine($"{comission:f2}"); } 
                    else { Console.WriteLine("error"); }
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500) {
                        comission = sales * 0.045;
                    } else if (sales > 500 && sales <= 1000) {
                        comission = sales * 0.075;
                    } else if (sales > 1000 && sales <= 10000) {
                        comission = sales * 0.1;
                    } else if (sales > 10000) {
                        comission = sales * 0.13;
                    }
                    if (!(sales < 0)) { Console.WriteLine($"{comission:f2}"); } 
                    else { Console.WriteLine("error"); }
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500) {
                        comission = sales * 0.055;
                    } else if (sales > 500 && sales <= 1000) {
                        comission = sales * 0.08;
                    } else if (sales > 1000 && sales <= 10000) {
                        comission = sales * 0.12;
                    } else if (sales > 10000) {
                        comission = sales * 0.145;
                    }
                    if (!(sales < 0)) { Console.WriteLine($"{comission:f2}"); } 
                    else { Console.WriteLine("error"); }
                    break;
                default: Console.WriteLine("error"); break;
            }
        }
    }
}
