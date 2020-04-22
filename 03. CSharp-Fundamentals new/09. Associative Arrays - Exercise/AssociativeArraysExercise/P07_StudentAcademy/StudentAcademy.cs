namespace P07_StudentAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentAcademy
    {
        static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int count = int.Parse(Console.ReadLine());

            while (count > 0)
            {
                string name = Console.ReadLine();

                double grade = double.Parse(Console.ReadLine());


                if (!students.ContainsKey(name))
                {
                    List<double> grades = new List<double>();

                    grades.Add(grade);

                    students.Add(name, grades);
                }
                else
                {
                    students[name].Add(grade);
                }

                count--;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var student in students.OrderByDescending(c => c.Value.Average()))
            {
                double avGrade = student.Value.Average();

                if (avGrade >= 4.5)
                {
                    sb.AppendLine($"{student.Key} -> {student.Value.Average():f2}");
                }                
            }

            string result = sb.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}