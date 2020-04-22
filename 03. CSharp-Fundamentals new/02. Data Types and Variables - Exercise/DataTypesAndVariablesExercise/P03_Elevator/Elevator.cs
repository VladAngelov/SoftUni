namespace P03_Elevator
{
    using System;

    public class Elevator
    {
        static void Main()
        {
            //Console.Write("Count people: ");
            int countPeople = int.Parse(Console.ReadLine());

            //Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            int courses = countPeople / capacity;

            int leftPeople = countPeople % capacity;

            while (leftPeople != 0)
            {
                courses++;

                if (leftPeople > capacity)
                {
                    leftPeople -= capacity;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(courses);

            //Console.WriteLine($"Courses: {courses}");
        }
    }
}