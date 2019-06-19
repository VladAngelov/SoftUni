using System;
using System.Globalization;
using System.Linq;
using Castle.Core.Internal;

namespace Cinema.DataProcessor
{
    using Data;
    using Data.Models;
    using ImportDto;

    using Newtonsoft.Json;

    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            ImportMoviesDto[] moviesDto = JsonConvert
                .DeserializeObject<ImportMoviesDto[]>(jsonString);

            List<Movie> validMovies = new List<Movie>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in moviesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                else
                {
                    var movie = new Movie
                    {
                        Title = dto.Title,
                        Director = dto.Director,
                        Duration = dto.Duration,
                        Genre = dto.Genre,
                        Rating = dto.Rating
                    };

                    validMovies.Add(movie);
                    sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:f2}!");
                }
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            ImportHallSeatDto[] hallSeatDto = JsonConvert
                .DeserializeObject<ImportHallSeatDto[]>(jsonString);

            List<Hall> validHalls = new List<Hall>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in hallSeatDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                else
                {
                    if (dto.Seats <= 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    List<Seat> seats = new List<Seat>();

                    for (int i = 0; i < dto.Seats; i++)
                    {
                        var seat = new Seat();
                        seats.Add(seat);
                    }

                    var hall = new Hall
                    {
                        Name = dto.Name,
                        Is3D = dto.Is3D,
                        Is4Dx = dto.Is4Dx,
                        Seats = seats
                    };

                    var typeM = string.Empty;

                    if (dto.Is4Dx && dto.Is3D)
                    {
                        typeM = "4Dx/3D";
                    }
                    else if (dto.Is3D && !dto.Is4Dx)
                    {
                        typeM = "3D";
                    }
                    else if (dto.Is4Dx && !dto.Is3D)
                    {
                        typeM = "4Dx";
                    }
                    else
                    {
                        typeM = "Normal";
                    }

                    validHalls.Add(hall);
                    sb.AppendLine($"Successfully imported {hall.Name}({typeM}) with {hall.Seats.Count} seats!");
                }
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer serializer =
                new XmlSerializer(
                    typeof(ImportProjectionDto[]),
                    new XmlRootAttribute("Projections"));

            ImportProjectionDto[] allProjections =
                (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Projection> validProjections = new List<Projection>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in allProjections)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }

                var movie = context.Movies.FirstOrDefault(x => x.Id == dto.MovieId);

                var hall = context.Halls.FirstOrDefault(x => x.Id == dto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = DateTime.ParseExact(
                           dto.DateTime,
                           "yyyy-MM-dd HH:mm:ss",
                           CultureInfo.InvariantCulture),
                    Movie = movie,
                    Hall = hall
                };

                if (context.Movies.IsNullOrEmpty())
                {
                    sb.AppendLine("Invalid Data!");
                    continue;
                }

                validProjections.Add(projection);
                sb.AppendLine($"Successfully imported projection " +
                              $"{projection.Movie.Title} on " +
                              $"{projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(
               typeof(ImportCustomerTicketDto[]),
               new XmlRootAttribute("Customers"));

            ImportCustomerTicketDto[] allCustomers =
                (ImportCustomerTicketDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Customer> validCustomers = new List<Customer>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in allCustomers)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance,
                    Tickets = dto.Tickets.Select(t => new Ticket
                    {
                        ProjectionId = t.ProjectionId,
                        Price = t.Price
                    })
                        .ToArray()
                };

                validCustomers.Add(customer);
                sb.AppendLine($"Successfully imported customer" +
                              $" {customer.FirstName} " +
                              $"{customer.LastName} with bought tickets: " +
                              $"{customer.Tickets.Count}!");
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);

            var validationResult = new List<ValidationResult>();

            bool isValid =
                Validator
                    .TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}