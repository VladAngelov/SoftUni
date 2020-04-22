namespace P08_BeerKegs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BeerKegs
    {
        static void Main()
        {
            Console.Write("Count of kegs: ");
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double> kegs = new Dictionary<string, double>(); 

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Model {i}: ");
                string model = Console.ReadLine();

                Console.Write("Radius: ");
                double radius = double.Parse(Console.ReadLine());

                Console.Write("Height: ");
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                kegs.Add(model, volume);
            }

            string biggestKeg = kegs.Aggregate((x, y) => x.Value > y.Value ? x : y).Key; 

            Console.WriteLine($"Biggest keg: {biggestKeg}");
        }
    }
}