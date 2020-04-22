namespace P10_TopNumber
{
    using System;
    using System.Text;

    public class TopNumber
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(IsTopNumber(number));
        }

        private static string IsTopNumber(int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= number; i++)
            {
                int sum = 0;

                bool oddDigit = false;

                int n = i;

                while (true)
                {
                    if (n == 0)
                    {
                        break;
                    }

                    int right = n % 10;

                    sum += right;

                    if (right % 2 != 0)
                    {
                        oddDigit = true;
                    }

                    n /= 10;
                }

                if (sum % 8 == 0 && oddDigit == true)
                {
                    sb.AppendLine(i.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}