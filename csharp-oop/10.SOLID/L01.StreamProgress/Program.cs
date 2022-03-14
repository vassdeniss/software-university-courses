namespace L01.StreamProgress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo fileInfo = new StreamProgressInfo(new File("file.txt", 20, 0));
            StreamProgressInfo musicInfo = new StreamProgressInfo(new Music("Imagine Dragons", "Bones", 20, 0));
            StreamProgressInfo excelInfo = new StreamProgressInfo(new Excel(10, 20, 100, 0));
        }
    }
}
