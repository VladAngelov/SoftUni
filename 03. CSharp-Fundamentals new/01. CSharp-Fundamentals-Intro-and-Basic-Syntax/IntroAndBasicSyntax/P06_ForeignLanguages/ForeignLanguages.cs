namespace P06_ForeignLanguages
{
    using System;

    public class ForeignLanguages
    {
        static void Main()
        {
            string unknown = "unknown";

            string english = "English";
            string spanish = "Spanish";

            string country = Console.ReadLine();

            switch (country)
            {
                case "England":
                case "USA":
                    Console.WriteLine(english); 
                    break;

                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine(spanish);
                    break;
                default:
                    Console.WriteLine(unknown);
                    break;
            }
        }
    }
}