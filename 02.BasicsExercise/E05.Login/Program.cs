using System;

namespace E05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = String.Empty;

            int tries = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            while (tries < 3)
            {
                string inputPassword = Console.ReadLine();

                if (inputPassword != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    tries++;
                    continue;
                }

                if (inputPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
            }

            Console.WriteLine($"User {username} blocked!");
        }
    }
}
