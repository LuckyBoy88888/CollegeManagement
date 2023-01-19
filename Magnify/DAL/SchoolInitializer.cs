using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Magnify.Models;

namespace Magnify.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{StudentID=1, FirstName="James", LastName="Smith", Grade=1},
                new Student{StudentID=2, FirstName="Jone", LastName="Williams", Grade=1},
                new Student{StudentID=3, FirstName="Thomas", LastName="Miller", Grade=2},
                new Student{StudentID=4, FirstName="Mary", LastName="Anderson", Grade=2},
                new Student{StudentID=5, FirstName="Susan", LastName="Wilson", Grade=3},
                new Student{StudentID=6, FirstName="Linda", LastName="Martin", Grade=3},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
                new Subject{SubjectID=1, Title="Multimedia"},
                new Subject{SubjectID=2, Title="Hardware"},
                new Subject{SubjectID=3, Title="Software"},
            };

            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var tearchers = new List<Teacher>
            {
                new Teacher{TeacherID=1, FirstName="Robert", LastName="Johnson", SubjectID=1},
                new Teacher{TeacherID=2, FirstName="Meredith", LastName="Brown", SubjectID=1},
                new Teacher{TeacherID=3, FirstName="Richard", LastName="Davis", SubjectID=2},
                new Teacher{TeacherID=4, FirstName="Margaret", LastName="Taylor", SubjectID=2},
                new Teacher{TeacherID=5, FirstName="Lisa", LastName="Thomas", SubjectID=3},
                new Teacher{TeacherID=6, FirstName="Elizabeth", LastName="Garcia", SubjectID=3},
            };

            tearchers.ForEach(t => context.Teachers.Add(t));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID=1, Title="About After Effect", SubjectID=1},
                new Course{CourseID=2, Title="Master Course of Animation", SubjectID=1},
                new Course{CourseID=3, Title="Raspberry Pi Mainboard", SubjectID=2},
                new Course{CourseID=4, Title="3th Generation Radeon CPU", SubjectID=2},
                new Course{CourseID=5, Title="Optical Cable Production", SubjectID=2},
                new Course{CourseID=6, Title="Introduction to Programming in C++", SubjectID=3},
                new Course{CourseID=7, Title="Ruby On Rails", SubjectID=3},
                new Course{CourseID=8, Title="Ubuntu Linux", SubjectID=3},
            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var courseRegistrations = new List<CourseRegistration>
            {
                new CourseRegistration{CourseRegistrationID=1, CourseID=1, StudentID=1},
                new CourseRegistration{CourseRegistrationID=2, CourseID=1, StudentID=2},
                new CourseRegistration{CourseRegistrationID=3, CourseID=2, StudentID=3},
                new CourseRegistration{CourseRegistrationID=4, CourseID=2, StudentID=4},
                new CourseRegistration{CourseRegistrationID=5, CourseID=2, StudentID=5},
                new CourseRegistration{CourseRegistrationID=6, CourseID=3, StudentID=5},
                new CourseRegistration{CourseRegistrationID=7, CourseID=3, StudentID=6},
                new CourseRegistration{CourseRegistrationID=8, CourseID=4, StudentID=1},
                new CourseRegistration{CourseRegistrationID=9, CourseID=4, StudentID=2},
                new CourseRegistration{CourseRegistrationID=10, CourseID=4, StudentID=6},
                new CourseRegistration{CourseRegistrationID=11, CourseID=5, StudentID=3},
                new CourseRegistration{CourseRegistrationID=12, CourseID=6, StudentID=1},
                new CourseRegistration{CourseRegistrationID=13, CourseID=6, StudentID=3},
                new CourseRegistration{CourseRegistrationID=14, CourseID=6, StudentID=4},
                new CourseRegistration{CourseRegistrationID=15, CourseID=6, StudentID=5},
                new CourseRegistration{CourseRegistrationID=16, CourseID=7, StudentID=2},
                new CourseRegistration{CourseRegistrationID=17, CourseID=7, StudentID=3},
                new CourseRegistration{CourseRegistrationID=18, CourseID=8, StudentID=4},
                new CourseRegistration{CourseRegistrationID=19, CourseID=8, StudentID=5},
                new CourseRegistration{CourseRegistrationID=20, CourseID=8, StudentID=6},
            };

            courseRegistrations.ForEach(c => context.CourseRegistrations.Add(c));
            context.SaveChanges();
        }
    }
}