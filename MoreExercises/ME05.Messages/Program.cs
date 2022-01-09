using System;

namespace ME05.Messages
{
    class Program
    {
        static char TranslateNum(string s)
        {
            int length = s.Length;
            string mainDigitString = s[0].ToString();
            int mainDigit = int.Parse(mainDigitString);
            int offset = 0;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset = ((mainDigit - 2) * 3) + 1;
            }
            else if (mainDigit == 0)
            {
                return ' ';
            }
            else
            {
                offset = (mainDigit - 2) * 3;
            }

            int letterIndex = (offset + length - 1);
            int unicode = 97 + letterIndex;

            char result = (char)unicode;

            return result;
        }

        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            string result = String.Empty;

            for (int i = 0; i < numberOfInputs; i++)
            {
                string num = Console.ReadLine();
                result += TranslateNum(num);
            }

            Console.WriteLine(result);
        }
    }
}
