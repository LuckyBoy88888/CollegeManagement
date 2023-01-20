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
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Course
        public ActionResult Index()
        {
            //var courses = db.Courses.Include(c => c.Subject);
            //return View(courses.ToList());
            return View();
        }

        // GET: All Courses
        [HttpGet]
        public JsonResult GetAllData()
        {
            var courses = db.Courses.Include(c => c.Subject);
            var data = (from host in courses
                        select new
                        {
                            CourseID = host.CourseID,
                            Title = host.Title,
                            SubjectTitle = host.Subject.Title
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            //ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Title");
            return View();
        }
        [HttpGet]
        public JsonResult GetCreate()
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
        [HttpPost]
        public JsonResult New([Bind(Include = "CourseID,Title,SubjectID")]Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return Json(course, JsonRequestBehavior.AllowGet);
        }
        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,SubjectID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Title", course.SubjectID);
            return View(course);
        }

        [HttpPost]
        public JsonResult Getcourse(int id)
        {
            Course course = db.Courses.Find(id);
            var data = new
            {
                CourseID = course.CourseID,
                Title = course.Title,
                SubjectID = course.SubjectID,
                SubjectTitle = course.Subject.Title
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,SubjectID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Title", course.SubjectID);
            return View(course);
        }
        [HttpPost]
        public JsonResult Update([Bind(Include = "CourseID,Title,SubjectID")]Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return Json(course, JsonRequestBehavior.AllowGet);
        }
        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        public JsonResult DeleteOne(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Json(course, JsonRequestBehavior.AllowGet);
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
