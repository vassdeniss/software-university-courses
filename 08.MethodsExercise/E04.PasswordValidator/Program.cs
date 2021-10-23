using System;

namespace E04.PasswordValidator
{
    class Program
    {
        static bool ValidatePasswordLength(string pass)
        {
            return pass.Length >= 6 && pass.Length <= 10;            
        }

        static bool ValidatePasswordText(string pass)
        {
            foreach (char c in pass)
            {
                bool checker = char.IsLetterOrDigit(c);
                if (!checker) return false;
            }
            return true;
        }

        static bool ValidatePasswordDigits(string pass)
        {
            int digitCount = 0;
            foreach (char c in pass)
            {
                bool checker = char.IsDigit(c);
                if (checker) digitCount++;
                if (digitCount >= 2) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isLengthValid = ValidatePasswordLength(password);
            bool isTextValid = ValidatePasswordText(password);
            bool isDigitsValid = ValidatePasswordDigits(password);

            if (!isLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isTextValid)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isDigitsValid)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isLengthValid && isTextValid && isDigitsValid)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
