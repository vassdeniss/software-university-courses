using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            string firstPath = @"..\..\..\input1.txt";
            string secondPath = @"..\..\..\input2.txt";
            string outputPath = @"..\..\..\output.txt";

            MergeTextFiles(firstPath, secondPath, outputPath);
        }

        public static void MergeTextFiles(string first, string second, string output)
        {
            using StreamReader readerFirst = new StreamReader(first);
            using StreamReader readerSecond = new StreamReader(second);
            using StreamWriter writer = new StreamWriter(output);

            bool isFirstEmpty = false;
            bool isSecondEmpty = false;

            string lineOne = readerFirst.ReadLine();
            string lineTwo = readerSecond.ReadLine();

            while (!isFirstEmpty && !isSecondEmpty)
            {
                if (lineOne == null)
                {
                    isFirstEmpty = true;
                    break;
                }

                if (lineTwo == null)
                {
                    isSecondEmpty = true;
                    break;
                }

                writer.WriteLine(lineOne);
                writer.WriteLine(lineTwo);

                lineOne = readerFirst.ReadLine();
                lineTwo = readerSecond.ReadLine();
            }

            if (isFirstEmpty) writer.WriteLine(lineTwo);
            if (isSecondEmpty) writer.WriteLine(lineOne);
        }
    }
}
