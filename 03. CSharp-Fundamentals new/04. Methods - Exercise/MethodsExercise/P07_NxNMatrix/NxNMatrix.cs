namespace P07_NxNMatrix
{
    using System;
    using System.Text;

    public class NxNMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMatrix(n));
        }

        private static string GetMatrix(int n)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sb.Append(n + " ");
                }

                sb.AppendLine();
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}