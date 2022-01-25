using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputPath = @"..\..\..\copyMe.png";
            string zipArchivePath = @"..\..\..\archive.zip";
            string extractedPath = @"..\..\..\extracted.png";

            ZipFileToArchive(inputPath, zipArchivePath);
            string fileName = Path.GetFileName(inputPath);
            ExtractFileFromArchive(zipArchivePath, fileName, extractedPath);
        }

        public static void ZipFileToArchive(string input, string zipArchive)
        {
            using ZipArchive zip = ZipFile.Open(zipArchive, ZipArchiveMode.Create);
            zip.CreateEntryFromFile(input, "copyMe.png");
        }

        public static void ExtractFileFromArchive(string zipArchive, string file, string output)
        {
            using ZipArchive zip = ZipFile.OpenRead(zipArchive);
            ZipArchiveEntry currZip = zip.GetEntry(file);
            currZip.ExtractToFile(output);
        }
    }
}
