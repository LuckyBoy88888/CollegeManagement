using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//Relationship
//Course 1 : n CourseRegistration
//Subject 1 : n Course 

namespace Magnify.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        public int NumberOfTeachers { get { return Subject != null ? Subject.Teachers.Count : 0; } }
        public int NumberOfStudents { get { return CourseRegistrations != null ? CourseRegistrations.Count : 0; } }
        public string AverageGradeOfStudents
        {
            get
            {
                if (CourseRegistrations == null)
                    return "0.00";

                int sum = 0;
                foreach (var courseRegistration in CourseRegistrations)
                {
                    sum += courseRegistration.Student.Grade;
                }

                return ((float)sum / (float)NumberOfStudents).ToString("0.00");
            }
        }
    }
}