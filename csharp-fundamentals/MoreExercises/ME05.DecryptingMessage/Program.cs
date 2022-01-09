using System;

namespace ME05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            string result = String.Empty;

            for (int i = 0; i < num; i++)
            {
                char c = char.Parse(Console.ReadLine());
                char offsetC = (char)(c + key);
                result += offsetC;
            }

            Console.WriteLine(result);
        }
    }
}
