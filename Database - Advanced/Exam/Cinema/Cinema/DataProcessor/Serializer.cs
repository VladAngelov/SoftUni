using Cinema.DataProcessor.ExportDto;

namespace Cinema.DataProcessor
{
    using Data;

    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movie = context
                .Projections
                .Select(x => new TopMovieDto
                {
                    MovieName = x.Movie.Title,
                    Rating = x.Movie.Rating,
                    TotalIncomes = x.Tickets.Sum(t => t.Price),
                    Customers = x.Movie.Projections.SelectMany(p => p.)

                })
                .ToArray();

            var moviesToExport =
                context
                    .Projections
                    .Where(p => p.Movie.Rating >= rating &&
                                p.Movie.Projections
                                    .Any(z => z.Tickets.Count > 0))
                    .Select(p => new 
                    {
                        MovieName = p.Movie.Title, // ok
                        Rating = $"{p.Movie.Rating:f2}", // ok
                        TotalIncomes = $"{p.Tickets.Sum(t => t.Price)}", // p.Tickets
                        Customers = context
                            .Tickets
                            .Select(c => new
                            {
                                FirstName = c.Customer.FirstName,
                                LastName = c.Customer.LastName,
                                Balance = c.Customer.Balance
                            })
                            .OrderByDescending(bal => bal.Balance)
                            .ThenBy(f => f.FirstName)
                            .ThenBy(l => l.LastName)
                            .ToArray()
                    })
                   // .Sum(t => t.TotalIncomes)
                    .OrderByDescending(r => r.Rating)
                    .ThenByDescending(total => total.TotalIncomes)
                    .Take(10)
                    .ToArray();

            var json = JsonConvert.SerializeObject(moviesToExport, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
        }
    }
}