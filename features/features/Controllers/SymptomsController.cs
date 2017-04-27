using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using features.Models;

namespace features.Controllers
{
    public class SymptomsController : Controller
    {
        private PetaByteContext db = new PetaByteContext();

        // GET: Symptoms
        public ActionResult Index()
        {
            var symptoms = db.Symptoms.Include(s => s.Department);
            return View(symptoms.ToList());
        }

        // GET: Symptoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // GET: Symptoms/Create
        public ActionResult Create()
        {
            ViewBag.deptId = new SelectList(db.Departments, "departmentsId", "dptName");
            return View();
        }

        // POST: Symptoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "symptomsId,symptName,deptId")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                db.Symptoms.Add(symptom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.deptId = new SelectList(db.Departments, "departmentsId", "dptName", symptom.deptId);
            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            ViewBag.deptId = new SelectList(db.Departments, "departmentsId", "dptName", symptom.deptId);
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "symptomsId,symptName,deptId")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptId = new SelectList(db.Departments, "departmentsId", "dptName", symptom.deptId);
            return View(symptom);
        }

        // GET: Symptoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Symptom symptom = db.Symptoms.Find(id);
            db.Symptoms.Remove(symptom);
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
