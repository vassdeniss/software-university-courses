using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            string from = Console.ReadLine();
            string to = Console.ReadLine();

            CopyAllFiles(from, to);
        }

        public static void CopyAllFiles(string input, string output)
        {
            if (Directory.Exists(output)) Directory.Delete(output);
            else Directory.CreateDirectory(output);

            string[] files = Directory.GetFiles(input);
            foreach (string file in files)
            {
                string fileName = output + "\\" + Path.GetFileName(file);
                File.Copy(file, fileName);
            }
        }
    }
}
