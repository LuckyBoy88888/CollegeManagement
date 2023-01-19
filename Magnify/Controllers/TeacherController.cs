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
    public class TeacherController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Teacher
        public ActionResult Index()
        {
            //var teachers = db.Teachers.Include(t => t.Subject);
            //return View(teachers.ToList());
            return View();
        }

        // GET: All Teachers
        [HttpGet]
        public JsonResult GetAllData()
        {
            var teachers = db.Teachers.Include(t => t.Subject);
            var data = (from host in teachers
                        select new
                        {
                            TeacherID = host.TeacherID,
                            FirstName = host.FirstName,
                            LastName = host.LastName,
                            SubjectTitle = host.Subject.Title
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            //ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Title");
            return View();
        }

        // GET: All Subjects
        [HttpGet]
        public JsonResult GetAllSubject()
        {
            var subjects = db.Subjects.ToList();
            var data = (from host in subjects
                        select new
                        {
                            SubjectID = host.SubjectID,
                            Title = host.Title
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Insert([Bind(Include = "TeacherID,FirstName,LastName,SubjectID")] Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();

            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetByID(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            var data = new
            {
                TeacherID = teacher.TeacherID,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                SubjectID = teacher.SubjectID
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Update([Bind(Include = "TeacherID,FirstName,LastName,SubjectID")] Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return Json(teacher, JsonRequestBehavior.AllowGet);
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
