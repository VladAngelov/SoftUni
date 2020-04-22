namespace P05_TriplesOfLatinLetters
{
    using System;
    using System.Text;

    public class TriplesOfLatinLetters
    {
        static void Main()
        {
            Console.Write("Input first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            Console.Write("Input second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                sb.Append(Char.ConvertFromUtf32(i) + " ");
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine("Result: " + result);
        }
    }
}