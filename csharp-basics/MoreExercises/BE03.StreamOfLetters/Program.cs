using System;

namespace BE03.StreamOfLetters {
    class Program {
        static void Main(string[] args) {
            bool sawC = false, sawO = false, sawN = false;
            string inputString = "", outputString = "";

            while (true) {
                string input = Console.ReadLine();

                if (input == "End") {
                    Console.WriteLine(outputString);
                    return;
                }

                foreach (char letter in input) {
                    if (letter >= 65 && letter <= 90
                        || letter >= 97 && letter <= 122) {

                        if (letter == 'c' && sawC == false) {
                            sawC = true;
                        } else if (letter == 'o' && sawO == false) {
                            sawO = true;
                        } else if (letter == 'n' && sawN == false) {
                            sawN = true;
                        } else {
                            inputString += letter;
                        }

                        if (sawN == true && sawO == true && sawC == true) {
                            sawN = false; sawO = false; sawC = false;
                            outputString += inputString + " ";
                            inputString = "";
                        }
                    }
                }
            }
        }
    }
}
