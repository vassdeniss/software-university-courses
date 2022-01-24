using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourcePath = @"..\..\..\example.png";
            string firstPath = @"..\..\..\firstBye.bin";
            string secondPath = @"..\..\..\secondBye.bin";
            string outputPath = @"..\..\..\example-joined.png";

            SplitBinaryFile(sourcePath, firstPath, secondPath);
            MergeBinaryFiles(firstPath, secondPath, outputPath);
        }

        public static void SplitBinaryFile(string source, string first, string second)
        {
            byte[] sourceBytes = File.ReadAllBytes(source);
            bool isEven = sourceBytes.Length % 2 == 0;

            using FileStream fileStreamFirst = new FileStream(first, FileMode.Create);
            fileStreamFirst.Write(sourceBytes, 0, isEven ? sourceBytes.Length / 2 : (sourceBytes.Length / 2) + 1);

            using FileStream fileStreamSecond = new FileStream(second, FileMode.Create);
            fileStreamSecond.Write(sourceBytes, 0, sourceBytes.Length / 2);
        }

        public static void MergeBinaryFiles(string first, string second, string joined)
        {
            byte[] firstArr = File.ReadAllBytes(first);
            byte[] secondArr = File.ReadAllBytes(second);

            byte[] writeArr = new byte[firstArr.Length + secondArr.Length];
            firstArr.CopyTo(writeArr, 0);
            secondArr.CopyTo(writeArr, firstArr.Length);

            File.WriteAllBytes(joined, writeArr);
        }
    }
}
