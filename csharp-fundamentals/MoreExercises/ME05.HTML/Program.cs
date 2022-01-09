using System;
using System.Text;

namespace ME05.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string title = Console.ReadLine();
            string article = Console.ReadLine();
            sb.Append($"<h1>\n    {title}\n</h1>\n<article>\n    {article}\n</article>\n");

            string comment = Console.ReadLine();
            while (comment != "end of comments")
            {
                sb.Append($"<div>\n    {comment}\n</div>\n");
                comment = Console.ReadLine();
            }

            Console.WriteLine(sb);
        }
    }
}
