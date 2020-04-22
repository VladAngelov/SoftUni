namespace P07_MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int maxCount = 0;
            int lastIndex = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    lastIndex = i;
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(numbers[lastIndex] + " ");
            }
        }
    }
}