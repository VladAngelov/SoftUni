namespace P01_AdvertisementMessage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdvertisementMessage
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            while (number > 0)
            {
                Console.WriteLine(GetRandomText(number));

                number--;
            }
        }

        private static string GetRandomText(int number)
        {
            string exellentproduct = "Excellent product.";
            string greatProduct = "Such a great product.";
            string alwaysUseThatProduct = "I always use that product.";
            string bestProduct = "Best product of its category.";
            string cantLive = "I can’t live without this product.";

            List<string> phrases = new List<string>()
            {
                exellentproduct,
                greatProduct,
                alwaysUseThatProduct,
                bestProduct,
                cantLive
            };

            
            string iFeelGood = "Now I feel good.";
            string succeededPrrroduct = "I have succeeded with this product.";
            string makesMiracles = "Makes miracles. I am happy of the results!";
            string cantBelieve = "I cannot believe but now I feel awesome.";
            string tryIt = "Try it yourself, I am very satisfied.";
            string feelGreat = "I feel great!";

            List<string> events = new List<string>()
            {
                iFeelGood,
                succeededPrrroduct,
                makesMiracles,
                cantBelieve,
                tryIt,
                feelGreat
            };


            string diana = "Diana";
            string petya = "Petya";
            string stella = "Stella";
            string elena = "Elena";
            string katya = "Katya";
            string iva = "Iva";
            string annie = "Annie";
            string eva = "Eva";

            List<string> authors = new List<string>()
            {
                diana,
                petya,
                stella,
                elena,
                katya,
                iva,
                annie,
                eva
            };


            string burgas = "Burgas";
            string sofia = "Sofia";
            string plovdiv = "Plovdiv";
            string varna = "Varna";
            string ruse = "Ruse";

            List<string> cities = new List<string>()
            {
                burgas,
                sofia,
                plovdiv,
                varna,
                ruse
            };
            
            Random random = new Random();

            int phraseIndex = random.Next(phrases.Count);
            int eventIndex = random.Next(events.Count);
            int authorIndex = random.Next(authors.Count);
            int cityIndex = random.Next(cities.Count);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} - {cities[cityIndex]}");

            string result = sb.ToString().TrimEnd();

            return result;
        }      
    }
}