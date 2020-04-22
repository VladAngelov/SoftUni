namespace P04_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Students
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Students(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }

        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            List<Students> students = new List<Students>(); 

            while (count > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Students student = new Students(firstName, lastName, grade);

                students.Add(student);

                count--;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in students.OrderByDescending(s => s.Grade))
            {
                sb.AppendLine(item.ToString());
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}