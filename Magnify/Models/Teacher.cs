using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//Relationship
//Subject 1 : n Teacher

namespace Magnify.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
    }
}