namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(
            //string name,
            //string phoneNumber = null,
            //DateTime? birthday = null
            )
        {
            //this.Name = name;
            //this.PhoneNumber = phoneNumber;
            //this.Birthday = birthday;

            this.HomeworkSubmissions = new List<Homework>();
            this.CourseEnrollments = new List<StudentCourse>();
        }

        //[Key]
        public int StudentId { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}