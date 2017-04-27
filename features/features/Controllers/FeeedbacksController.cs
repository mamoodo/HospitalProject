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
    public class FeeedbacksController : Controller
    {
        private PetaByteContext db = new PetaByteContext();

        // GET: Feeedbacks
        public ActionResult Index()
        {
            return View(db.Feeedbacks.ToList());
        }

        // GET: Feeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeedback feeedback = db.Feeedbacks.Find(id);
            if (feeedback == null)
            {
                return HttpNotFound();
            }
            return View(feeedback);
        }

        // GET: Feeedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
        {
            if (ModelState.IsValid)
            {
                db.Feeedbacks.Add(feeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feeedback);
        }

        // GET: Feeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeedback feeedback = db.Feeedbacks.Find(id);
            if (feeedback == null)
            {
                return HttpNotFound();
            }
            return View(feeedback);
        }

        // POST: Feeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feedbackId,firstName,lastName,email,subject,timestamp")] Feeedback feeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feeedback);
        }

        // GET: Feeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feeedback feeedback = db.Feeedbacks.Find(id);
            if (feeedback == null)
            {
                return HttpNotFound();
            }
            return View(feeedback);
        }

        // POST: Feeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feeedback feeedback = db.Feeedbacks.Find(id);
            db.Feeedbacks.Remove(feeedback);
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
