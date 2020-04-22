namespace P03_PassedOrFailed
{
    using System;

    public class PassedOrFailed
    {
        static void Main()
        {
            string passed = "Passed!";
            string notPassed = "Failed!";

            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine(passed);
            }
            else
            {
                Console.WriteLine(notPassed);
            }
        }
    }
}