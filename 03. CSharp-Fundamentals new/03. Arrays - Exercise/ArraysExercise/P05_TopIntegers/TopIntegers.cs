namespace P05_TopIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TopIntegers
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> biggerElements = new List<int>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    biggerElements.Add(numbers[i]);
                }
            }

            biggerElements.Add(numbers[numbers.Length - 1]);

            string result = string.Join(' ', biggerElements);

            Console.WriteLine(result);
        }
    }
}