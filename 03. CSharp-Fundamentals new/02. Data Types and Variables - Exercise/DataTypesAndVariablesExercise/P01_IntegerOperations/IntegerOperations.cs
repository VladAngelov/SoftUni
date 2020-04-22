namespace P01_IntegerOperations
{
    using System;

    public class IntegerOperations
    {
        static void Main()
        {

            int sum = 0;

            //Console.Write("Input first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            //Console.Write("Input second nnumber: ");
            int secondNumber = int.Parse(Console.ReadLine());

            sum = firstNumber + secondNumber;
            //Console.WriteLine($"1 and 2 nums sum: {sum}");

            //Console.Write("Input third num for divide: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            sum = sum / thirdNumber;
            //Console.WriteLine($"Sum after divide: {sum}");

            //Console.Write("Number for multiply: ");
            int forthNumber = int.Parse(Console.ReadLine());

            sum = sum * forthNumber;
            //Console.WriteLine($"Sum after multiply: {sum}");

            Console.WriteLine(sum);
        }
    }
}