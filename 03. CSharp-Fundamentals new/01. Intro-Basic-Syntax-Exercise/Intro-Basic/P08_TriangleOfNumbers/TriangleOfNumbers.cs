namespace P08_TriangleOfNumbers
{
    using System;
    using System.Text;

    public class TriangleOfNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    sb.Append(i + " ");
                }

                sb.AppendLine();
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}