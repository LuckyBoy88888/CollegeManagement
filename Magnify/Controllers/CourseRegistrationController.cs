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
    public class CourseRegistrationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CourseRegistration
        public ActionResult Index()
        {
            var courseRegistrations = db.CourseRegistrations.Include(c => c.Course).Include(c => c.Student);
            return View(courseRegistrations.ToList());
        }

        // GET: All CourseRegistrations
        [HttpGet]
        public JsonResult GetAllData()
        {
            var courseRegistrations = db.CourseRegistrations.Include(c => c.Course).Include(c => c.Student);
            var data = (from host in courseRegistrations
                        select new
                        {
                            CourseRegistrationID = host.CourseRegistrationID,
                            CourseTitle = host.Course.Title,
                            StudentFirstName = host.Student.FirstName,
                            StudentLastName = host.Student.LastName
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: CourseRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // GET: CourseRegistration/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: CourseRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseRegistrationID,CourseID,StudentID")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.CourseRegistrations.Add(courseRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
            return View(courseRegistration);
        }

        // GET: CourseRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
            return View(courseRegistration);
        }

        // POST: CourseRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseRegistrationID,CourseID,StudentID")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
            return View(courseRegistration);
        }

        // GET: CourseRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // POST: CourseRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            db.CourseRegistrations.Remove(courseRegistration);
            db.SaveChanges();
            return RedirectToAction("Index");
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
