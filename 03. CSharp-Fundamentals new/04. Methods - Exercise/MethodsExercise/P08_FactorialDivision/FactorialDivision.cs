namespace P08_FactorialDivision
{
    using System;

    public class FactorialDivision
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int secondNumber = int.Parse(Console.ReadLine());

            double result = GetFactorialDivision(firstNumber, secondNumber);

            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorialDivision(int firstNumber, int secondNumber)
        {
            double firstFacturial = 1;

            double secondFactorial = 1;

            for (int i = firstNumber; i >= 1; i--)
            {
                firstFacturial = firstFacturial * i;
            }

            for (int i = secondNumber; i >= 1; i--)
            {
                secondFactorial = secondFactorial * i;
            }

            double result = firstFacturial / secondFactorial;

            return result;
        }
    }
}