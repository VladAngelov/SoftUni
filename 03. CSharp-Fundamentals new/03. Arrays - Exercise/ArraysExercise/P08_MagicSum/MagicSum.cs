namespace P08_MagicSum
{
    using System;
    using System.Linq;

    public class MagicSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    if (numbers[i] + numbers[k] == magicSum)
                    {
                        Console.WriteLine(numbers[i] + " " + numbers[k]);
                    }
                }
            }
        }
    }
}