namespace P03_ZigZagArrays
{
    using System;
    using System.Text;

    public class ZigZagArrays
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstAray = new int[n];
            int[] secondAray = new int[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length > 2)
                {
                    break;
                }

                firstAray[i] = int.Parse(input[0]);

                secondAray[i] = int.Parse(input[1]);

                if (i % 2 == 0)
                {
                    firstAray[i] = int.Parse(input[1]);

                    secondAray[i] = int.Parse(input[0]);

                }
            }

            StringBuilder firstString = new StringBuilder();
            StringBuilder secondString = new StringBuilder();

            foreach (int num in firstAray)
            {
                firstString.Append(num + " ");
            }

            foreach (int num in secondAray)
            {
                secondString.Append(num + " ");
            }

            Console.WriteLine(secondString.ToString().TrimEnd());
            Console.WriteLine(firstString.ToString().TrimEnd());
        }
    }
}