using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


//Relationship
//Course 1 : n CourseRegistration
//Student 1 : n CourseRegistration

namespace Magnify.Models
{
    public class CourseRegistration
    {
        public int CourseRegistrationID { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}