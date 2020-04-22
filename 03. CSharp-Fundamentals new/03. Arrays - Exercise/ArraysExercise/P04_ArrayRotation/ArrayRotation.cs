namespace P04_ArrayRotation
{
    using System;
    using System.Linq;

    public class ArrayRotation
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfIndexes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfIndexes; i++)
            {
                int[] rotated = new int[numbers.Length];
                rotated[numbers.Length - 1] = numbers[0];

                for (int j = 0; j < rotated.Length - 1; j++)
                {
                    rotated[j] = numbers[j + 1];
                }

                numbers = rotated;
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}