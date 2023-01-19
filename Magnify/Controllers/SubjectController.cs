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
    public class SubjectController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Subjects
        [HttpGet]
        public JsonResult GetAllData()
        {
            var subjects = db.Subjects.ToList();
            var data = (from host in subjects
                        select new
                        {
                            SubjectID = host.SubjectID,
                            Title = host.Title,
                        }).ToArray();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // GET: Subject/Details/5
        public JsonResult GetByID(int id)
        {
            Subject subject = db.Subjects.Find(id);
            var data = new
            {
                SubjectID = subject.SubjectID,
                Title = subject.Title
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Insert([Bind(Include = "SubjectID,Title")] Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return Json(subject, JsonRequestBehavior.AllowGet);
        }
        
        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Update([Bind(Include = "SubjectID,Title")] Subject subject)
        {
            db.Entry(subject).State = EntityState.Modified;
            db.SaveChanges();
            return Json(subject, JsonRequestBehavior.AllowGet);
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return Json(subject, JsonRequestBehavior.AllowGet);
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
