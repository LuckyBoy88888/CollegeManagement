using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//Relationship
//Subject 1 : n Course
//Subject 1 : n Teacher

namespace Magnify.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        public int NumberOfStudents
        {
            get
            {
                if (Courses == null) return 0;

                int sum = 0;
                foreach (var course in Courses)
                {
                    sum += course.NumberOfStudents;
                }

                return sum;
            }
        }

    }
}