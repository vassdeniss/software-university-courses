using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\TestFolder";
            string outputPath = @"..\..\..\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folder, string output)
        {
            double sum = 0;

            DirectoryInfo dir = new DirectoryInfo(folder);
            FileInfo[] info = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo fi in info) sum += fi.Length;

            sum = sum / 1024 / 1024;
            File.WriteAllText(output, sum.ToString());
        }
    }
}
