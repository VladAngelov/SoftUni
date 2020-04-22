namespace P03_Articles2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Articles2
    {
        public Articles2(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            string result = $"{this.Title} - {this.Content}: {this.Author}";

            return result;
        }

        static void Main()
        {
            List<Articles2> articles = new List<Articles2>();

            int count = int.Parse(Console.ReadLine());


            while (count > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = input[0];

                string content = input[1];

                string author = input[2];

                Articles2 article = new Articles2(title, content, author);

                articles.Add(article);

                count--;
            }

            string command = Console.ReadLine().ToLower();

            StringBuilder sb = new StringBuilder();

            switch (command)
            {
                case "title":
                    foreach (var item in articles.OrderBy(a => a.Title))
                    {
                        sb.AppendLine(item.ToString());
                    }
                    break;

                case "content":
                    foreach (var item in articles.OrderBy(a => a.Content))
                    {
                        sb.AppendLine(item.ToString());
                    }
                    break;

                case "author":
                    foreach (var item in articles.OrderBy(a => a.Author))
                    {
                        sb.AppendLine(item.ToString());
                    }
                    break;
                default:
                    break;
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}