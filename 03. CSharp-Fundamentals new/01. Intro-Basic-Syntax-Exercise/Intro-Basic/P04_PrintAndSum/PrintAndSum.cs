namespace P04_PrintAndSum
{
    using System;
    using System.Text;

    public class PrintAndSum
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int secondNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                sum += i;

                sb.Append(i + " ");
            }

            string sumString = $"Sum: {sum}";
            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
            Console.WriteLine(sumString);
        }
    }
}