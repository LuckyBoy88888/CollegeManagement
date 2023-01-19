using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//Relationship
//Student 1 : n CourseRegistration

namespace Magnify.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int Grade { get; set; }

        public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; }

        public int RespectiveGrade { get { return Grade; } }
        public int RespectiveGradeSubject(Subject subject)
        {
            foreach (var course in subject.Courses)
            {
                foreach (var courseRegistration in course.CourseRegistrations)
                {
                    if (courseRegistration.Student.StudentID == StudentID)
                    {
                        return Grade;
                    }
                }
            }

            return 0;
        }
    }
}