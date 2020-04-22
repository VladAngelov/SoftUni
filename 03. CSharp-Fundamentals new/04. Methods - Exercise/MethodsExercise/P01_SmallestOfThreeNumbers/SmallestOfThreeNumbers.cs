namespace P01_SmallestOfThreeNumbers
{
    using System;
    using System.Linq;

    public class SmallestOfThreeNumbers
    {
        static void Main()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbers[i] = number;
            }

            int smalestNumber = numbers.Min();

            Console.WriteLine(smalestNumber);
        }
    }
}