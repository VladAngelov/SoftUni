namespace P06_StrongNumber
{
    using System;

    public class StrongNumber
    {
        static void Main()
        {
            string yes = "yes";
            string no = "no";

            int inputNumber = int.Parse(Console.ReadLine());

            var numbersToString = inputNumber.ToString();

            int total = 0;

            foreach (var number in numbersToString)
            {
                int val = (int)Char.GetNumericValue(number);

                int sum = 1;

                for (int i = 1; i <= val; i++)
                {
                    sum = sum * i;
                }

                total = total + sum;
            }

            if (total == inputNumber)
            {
                Console.WriteLine(yes);
            }
            else
            {
                Console.WriteLine(no);
            }
        }
    }
}