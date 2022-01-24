using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryPath = @"..\..\..\example.png";
            string bytesPath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.txt";

            ExtractBytesFromBinaryFile(binaryPath, bytesPath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binary, string bytes, string output)
        {
            using StreamReader reader = new StreamReader(bytes);

            byte[] byteArr = File.ReadAllBytes(binary);
            List<string> bytesToSearch = new List<string>();
            StringBuilder sb = new StringBuilder();

            string line = reader.ReadLine();
            while (line != null)
            {
                bytesToSearch.Add(line);
                line = reader.ReadLine();
            }

            foreach (byte currByte in byteArr)
            {
                if (bytesToSearch.Contains(currByte.ToString()))
                {
                    sb.Append(currByte.ToString());
                }
            }

            using StreamWriter writer = new StreamWriter(output);
            writer.WriteLine(sb.ToString().Trim());
        }
    }
}
