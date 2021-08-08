using System;

namespace E05.PasswordGenerator {
    class Program {
        static void Main(string[] args) {
            int number = int.Parse(Console.ReadLine());
            int letter = int.Parse(Console.ReadLine());

            char[] alphabet = 
            { 
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' 
            }; 

            // Symbol I
            for (int i = 1; i <= number; i++) {
                // Symbol II
                for (int j = 1; j <= number; j++) {
                    // Symbol III
                    for (int k = 0; k < letter; k++) {
                        char charOne = alphabet[k]; 
                        // Symbol IV
                        for (int m = 0; m < letter; m++) {
                            char charTwo = alphabet[m];
                            // Symbol V
                            for (int n = 0; n <= number; n++) {
                                if (n > i && n > j) {
                                    Console.Write($"{i}{j}{charOne}{charTwo}{n} ");
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
