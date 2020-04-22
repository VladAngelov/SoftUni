namespace P02_Division
{
    using System;

    public class Division
    {
        static void Main()
        {
            string errorMessage = "Not divisible";

            int devision = 0;

            int input = int.Parse(Console.ReadLine());

            if (input % 2 == 0)
            {
                devision = 2;
            }
            if (input % 3 == 0)
            {
                devision = 3;
            }
            if (input % 6 == 0)
            {
                devision = 6;
            }
            if (input % 7 == 0)
            {
                devision = 7;
            }
            if (input % 10 == 0)
            {
                devision = 10;
            }

            string message = $"The number is divisible by {devision}";

            if (devision == 0 )
            {
                Console.WriteLine(errorMessage);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}