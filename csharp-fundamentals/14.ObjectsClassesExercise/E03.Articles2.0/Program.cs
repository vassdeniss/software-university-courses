using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.Articles2._0
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public List<Article> ArticleList { get; set; }

        public Article() => ArticleList = new List<Article>();

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int articleQty = int.Parse(Console.ReadLine());

            Article article = new Article();
            for (int i = 0; i < articleQty; i++)
            {
                string[] aritcleSettings = Console.ReadLine().Split(", ");

                string title = aritcleSettings[0];
                string content = aritcleSettings[1];
                string author = aritcleSettings[2];

                Article newArticle = new Article()
                {
                    Title = title,
                    Content = content,
                    Author = author
                };
                article.ArticleList.Add(newArticle);
            }

            PrintArticleList(article);
        }

        static void PrintArticleList(Article article)
        {
            string printCriteria = Console.ReadLine();

            switch (printCriteria)
            {
                case "title":
                    foreach (Article art in article.ArticleList.OrderBy(t => t.Title))
                        Console.WriteLine(art);
                    break;
                case "content":
                    foreach (Article art in article.ArticleList.OrderBy(c => c.Content))
                        Console.WriteLine(art);
                    break;
                case "author":
                    foreach (Article art in article.ArticleList.OrderBy(a => a.Author))
                        Console.WriteLine(art);
                    break;
            }
        }
    }
}
