namespace P02_SumDigits
{
    using System;

    public class SumDigits
    {
        static void Main()
        {
            int total = 0;

            string input = Console.ReadLine();

            foreach (var number in input)
            {
                int val = (int)Char.GetNumericValue(number);

                total = total + val;
            }

            Console.WriteLine(total);
        }
    }
}