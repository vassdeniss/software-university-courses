using System;

namespace BE04.CarNumber {
    class Program {
        static void Main(string[] args) {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = 1000; i <= 9999; i++) {
                bool flag = false;
                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++) {
                    int compareNumber = currentNum[j] - '0';
                    if (compareNumber < start 
                        || compareNumber > end) {
                        flag = true;
                        break;
                    }
                }

                if (flag) { continue; }
                bool checkEvenOdd = currentNum[0] % 2 == 0 && currentNum[3] % 2 != 0;
                bool checkOddEven = currentNum[0] % 2 != 0 && currentNum[3] % 2 == 0;
                bool checkHigher = currentNum[0] > currentNum[3];
                bool checkMiddleEven = (currentNum[1] + currentNum[2]) % 2 == 0;
                
                if ((checkEvenOdd || checkOddEven)
                    && checkHigher && checkMiddleEven) {
                    Console.Write($"{currentNum} ");
                }
            }
        }
    }
}
