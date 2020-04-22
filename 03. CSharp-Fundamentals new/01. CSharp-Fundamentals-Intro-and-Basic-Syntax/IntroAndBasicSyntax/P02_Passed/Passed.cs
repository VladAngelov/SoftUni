namespace P02_Passed
{
    using System;

    public class Passed
    {
        static void Main()
        {
            string passed = "Passed!";

            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine(passed);
            }
        }
    }
}