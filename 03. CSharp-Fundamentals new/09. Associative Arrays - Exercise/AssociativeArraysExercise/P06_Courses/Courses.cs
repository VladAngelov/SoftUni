namespace P06_Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Courses
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                if (!courses.ContainsKey(input[0]))
                {
                    List<string> students = new List<string>();

                    students.Add(input[1]);

                    courses.Add(input[0], students);
                }
                else
                {
                    courses[input[0]].Add(input[1]);
                }

                input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var course in courses.OrderByDescending(c => c.Value.Count))
            {
                sb.AppendLine($"{course.Key}: {course.Value.Count}");

                foreach (var item in course.Value.OrderBy(s => s))
                {
                    sb.AppendLine($"-- {item}");
                }
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}