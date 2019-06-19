namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using Models;
    using Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);

                // 01
                //string command = "minor";
                //Console.WriteLine(GetBooksByAgeRestriction(db, command));

                // 02
                // Console.WriteLine(GetGoldenBooks(db));

                // 03
                // Console.WriteLine(GetBooksByPrice(db));

                // 04
                // int year = 2000;
                // Console.WriteLine(GetBooksNotReleasedIn(db, year));

                // 05
                // string input = "horror mystery drama";
                // Console.WriteLine(GetBooksByCategory(db, input));

                // 06
                // string date = "12-04-1992";
                // Console.WriteLine(GetBooksReleasedBefore(db, date));

                // 07
                // string input = "e";
                // Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                // 08
                // string input = "sK";
                // string input = "WOR";
                // Console.WriteLine(GetBookTitlesContaining(db, input));

                // 09
                // string input = "R";
                // Console.WriteLine(GetBooksByAuthor(db, input));

                // 10
                // int lengthCheck = 12;
                // Console.WriteLine(CountBooks(db, lengthCheck));

                // 11
                // Console.WriteLine(CountCopiesByAuthor(db));

                // 12
                // Console.WriteLine(GetTotalProfitByCategory(db));

                // 13
                // Console.WriteLine(GetMostRecentBooks(db));

                // 14
                // IncreasePrices(db);

                // 15
                // Console.WriteLine(RemoveBooks(db));
            }
        }

        // 01 Judge break
        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = db.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    Title = b.Title
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title}"));

            return result;
        }

        // 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title

                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title}"));

            return result;
        }

        // 03
        public static string GetBooksByPrice(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(bp => bp.Price)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - ${b.Price:F2}"));

            return result;
        }

        // 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title}"));

            return result;
        }

        // 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            if (input == null)
            {
                input = Console.ReadLine();
            }

            var categories = input
                .ToLower()
                .Split(new[] { ' ', '\t', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

            string result = string
                .Join(Environment.NewLine,
                    context.Books
                    .Where(b => b.BookCategories
                        .Select(bc => bc.Category.Name.ToLower())
                        .Intersect(categories)
                        .Any())
                    .Select(b => b.Title)
                    .OrderBy(t => t));

            return result;
        }

        // 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            if (date == null)
            {
                date = Console.ReadLine();
            }

            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return result;
        }

        // 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                authors.Select(a => $"{a.FullName}"));

            return result;
        }

        // 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title
                    .ToLower()
                    .Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    Title = b.Title
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title}"));

            return result;
        }

        // 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var book = context.Books
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(a => a.BookId)
                .Select(x => new
                {
                    Title = x.Title,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName
                })
                .ToList();

            string result = string.Join(Environment.NewLine,
                book.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));

            return result;
        }

        // 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => new
                {
                    Title = b.Title
                })
                .ToList();

            int result = books.Count;

            return result;
        }

        // 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BooksCount = x.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.BooksCount)
                .ToList();

            string result =
                string.Join(Environment.NewLine,
                    authors.Select(x => $"{x.FirstName} {x.LastName} - {x.BooksCount}"));

            return result;
        }

        // 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
                })
                .OrderByDescending(t => t.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            string result =
                string.Join(Environment.NewLine, categories
                    .Select(x => $"{x.CategoryName} ${x.TotalProfit}"));

            return result;
        }

        // 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                        .Select(e => new
                        {
                            e.Book.Title,
                            e.Book.ReleaseDate
                        })
                        .OrderByDescending(e => e.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var result = books.Count;

            context.Books.RemoveRange(books);

            int affectedRows = context.SaveChanges();

            return result;
        }
    }
}