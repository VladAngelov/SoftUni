namespace P01_Train
{
    using System;
    using System.Text;

    public class Train
    {
        static void Main()
        {
            int loops = int.Parse(Console.ReadLine());

            int[] intArray = new int[loops];

            for (int i = 0; i < loops; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;

            StringBuilder sb = new StringBuilder();
 
            foreach (int num in intArray)
            {
                sum = sum + num;

                sb.Append(num + " ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
            Console.WriteLine(sum);
        }
    }
}