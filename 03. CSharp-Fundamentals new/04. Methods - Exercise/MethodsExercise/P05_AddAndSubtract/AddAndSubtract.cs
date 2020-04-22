namespace P05_AddAndSubtract
{
    using System;

    public class AddAndSubtract
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(SumMethod(firstNumber, secondNumber, thirdNumber));
        }

        private static int SumMethod(int firstNumber, int secondNumber, int thirdNumber)
        {
            int sum = firstNumber + secondNumber - thirdNumber;

            return sum;
        }
    }
}