using System;
using System.Text;

namespace EP01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string decryptedMessage = encryptedMessage;

            string input = Console.ReadLine();
            while (input != "Decode")
            {
                string[] cmd = input.Split('|');

                if (cmd[0] == "Move")
                    decryptedMessage = decryptedMessage[int.Parse(cmd[1])..] + decryptedMessage[..int.Parse(cmd[1])];
                else if (cmd[0] == "Insert")
                    decryptedMessage = decryptedMessage.Insert(int.Parse(cmd[1]), cmd[2]);
                else if (cmd[0] == "ChangeAll")
                    decryptedMessage = decryptedMessage.Replace(cmd[1], cmd[2]);

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {decryptedMessage}");
        }
    }
}
