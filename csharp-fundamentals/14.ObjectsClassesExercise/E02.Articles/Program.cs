using System;

namespace E02.Articles
{
    class Article
    {
        private string _title;
        private string _content;
        private string _author;

        public Article(string title, string content, string author)
        {
            _title = title;
            _content = content;
            _author = author;
        }

        public void Edit(string content) => _content = content;
        public void ChangeAuthor(string author) => _author = author;
        public void Rename(string title) => _title = title;

        public override string ToString()
        {
            return $"{_title} - {_content}: {_author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArticle = Console.ReadLine().Split(", ");
            int cmdQty = int.Parse(Console.ReadLine());

            string title = inputArticle[0];
            string content = inputArticle[1];
            string author = inputArticle[2];

            Article article = new Article(title, content, author);
            for (int i = 0; i < cmdQty; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");

                if (cmd[0] == "Edit")
                {
                    article.Edit(cmd[1]);
                }
                else if (cmd[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(cmd[1]);
                }
                else
                {
                    article.Rename(cmd[1]);
                }
            }

            Console.WriteLine(article);
        }
    }
}
