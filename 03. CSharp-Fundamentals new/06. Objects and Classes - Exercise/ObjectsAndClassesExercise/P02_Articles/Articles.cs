namespace P02_Articles
{
    using System;

    public class Articles
    {
        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            string result = $"{this.Title} - {this.Content}: {this.Author}";

            return result;
        }

        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Articles articles = new Articles(title, content, author);

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Edit":
                        articles.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        articles.ChangeAuthor(command[1]);
                        break;
                    case "Rename":
                        articles.Rename(command[1]);
                        break;

                    default:
                        break;
                }

                count--;
            }

            string result = $"{articles.Title} - {articles.Content}: {articles.Author}";

            Console.WriteLine(result);
        }
    }
}