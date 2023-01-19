using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Magnify.DAL;
using Magnify.Models;

namespace Magnify.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Students
        [HttpGet]
        public JsonResult GetAllData()
        {
            var students = db.Students.ToList();
            var data = (from host in students
                        select new
                        {
                            StudentID = host.StudentID,
                            FirstName = host.FirstName,
                            LastName = host.LastName,
                            Grade = host.Grade
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Student/Details/5
        [HttpGet]
        public JsonResult GetByID(int id)
        {
            Student student = db.Students.Find(id);
            var data = new
            {
                StudentID = student.StudentID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Insert([Bind(Include = "StudentID,FirstName,LastName,Grade")] Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Update([Bind(Include = "StudentID,FirstName,LastName,Grade")] Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
