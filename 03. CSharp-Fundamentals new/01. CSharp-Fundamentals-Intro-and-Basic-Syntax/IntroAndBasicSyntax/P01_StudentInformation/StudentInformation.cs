namespace P01_StudentInformation
{
    using System;

    public class StudentInformation
    {
        static void Main()
        {
            string name = Console.ReadLine();

            int ages = int.Parse(Console.ReadLine());

            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}, Age: {ages}, Grade: {grade:f2}");
        }
    }
}