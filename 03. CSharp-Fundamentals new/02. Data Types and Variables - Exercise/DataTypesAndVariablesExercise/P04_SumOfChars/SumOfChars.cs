namespace P04_SumOfChars
{
    using System;

    public class SumOfChars
    {
        static void Main()
        {
            Console.Write("Input count of letters: ");
            int counter = int.Parse(Console.ReadLine());

            int total = 0;

            for (int i = 1; i <= counter; i++)
            {
                Console.Write($"Input letter number {i}: ");
                char letter = char.Parse(Console.ReadLine());

                total = total + (int)letter;
            }

            Console.WriteLine("The sum equals: " + total);
        }
    }
}