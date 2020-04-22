namespace P06_EqualSum
{
    using System;
    using System.Linq;

    public class EqualSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;
            int index = 0;

            while (index != numbers.Length)
            {
                for (int i = 0; i < index; i++)
                {
                    leftSum += numbers[i];
                }

                for (int i = numbers.Length - 1; i > index; i--)
                {
                    rightSum += numbers[i];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(index);
                    return;
                }

                index++;
                leftSum = 0;
                rightSum = 0;
            }

            Console.WriteLine("no");
        }
    }
}