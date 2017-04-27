using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using features.Models;

namespace features.Controllers
{
    public class HomeController : Controller
    {
        private PetaByteContext db = new PetaByteContext();
        

        /*Actiong for Homepage Index*/
        /*********************/
        // GET: Home
        public ActionResult Index()
        {
            List<HospitalEvent> events = db.HospitalEvents.Take(3).ToList();
            return View(events);
        }

        /*Action for event details*/
        /*************************/
        public ActionResult EventDetails(int? id)
        {
            HospitalEvent events = db.HospitalEvents.Single(evnt => evnt.eventsId == id);

            return View(events);
        }

        /*Action for all events on the Homepage*/
        /**************************************/
        public ActionResult Allevents()
        {
            return View(db.HospitalEvents.ToList());
        }

        public ActionResult Allfeedbacks()
        {
            /*List<Feeedback> feedback = db.Feeedbacks.OrderByDescending(e => e.timestamp).ToList();*/
            return View(db.Feeedbacks.ToList());
        }

        /*        public ActionResult Recentfeedbakcs()
                {

                    return View(db.Feeedbacks.OrderByDescending(f => f.timestamp ).ToList());
                }*/


        /*Action for recent feedbacks*/
        /****************************/
        public ActionResult Recentfeedbaks()
        {
           List<Feeedback> feedbacks = db.Feeedbacks.OrderByDescending(e => e.timestamp).Take(3).ToList();
           return View(feedbacks);
        }


        /*Action to add feedback on a partial view*/
        /*****************************************/
        public PartialViewResult Addfeedbacks()
        {
            return PartialView("Addfeedbacks");
        }


        /*Action to add the new feedback to the database*/
        /***********************************************/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addfeedbacks([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
        {
                db.Feeedbacks.Add(feeedback);
                db.SaveChanges();
                return RedirectToAction("Allfeedbacks");

        }

        /*Action to display all of the departments*/
        /*****************************************/
        public ActionResult AllDepartments()
        {
            return View(db.Departments.ToList());
        }

        /*Action to display the department detials including the symptoms treated in that department*/
        /*******************************************************************************************/
        public ActionResult DeptDetails(int? id)
        {
            Department department = db.Departments.Find(id);
            List<Symptom> symptoms = db.Symptoms.Where(smp => smp.deptId == id).ToList();

            DepartmentSymptoms depSymp = new DepartmentSymptoms();
            depSymp.department = department;
            depSymp.symptoms = symptoms;

            return View(department);
        }

        /*        [HttpPost]
                [ValidateAntiForgeryToken]
                public PartialViewResult Addfeedbacks([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
                {
                    if (ModelState.IsValid)
                    {
                        db.Feeedbacks.Add(feeedback);
                        db.SaveChanges();
                        return RedirectToAction("Allfeedbacks");
                    }

                    return PartialView(feeedback);
                }*/


        /*        public ActionResult Addfeedback()
                {
                    return View();
                }
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Addfeedback([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
                {
                    if (ModelState.IsValid)
                    {
                        db.Feeedbacks.Add(feeedback);
                        db.SaveChanges();
                        return RedirectToAction("Allfeedbacks");
                    }

                    return View(feeedback);
                }*/

        /*        public ActionResult Addfeedback()
                {
                    return View();
                }
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Addfeedback([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
                {
                    if (ModelState.IsValid)
                    {
                        db.Feeedbacks.Add(feeedback);
                        db.SaveChanges();
                        return RedirectToAction("Allfeedbacks");
                    }

                    return View(feeedback);
                }*/
        /*        [HttpPost]
                [ValidateAntiForgeryToken]
                public PartialViewResult Addfeedback([Bind(Include = "feedbackId,firstName,lastName,email,subject,feedback,timestamp")] Feeedback feeedback)
                {
                    if (ModelState.IsValid)
                    {
                        db.Feeedbacks.Add(feeedback);
                        db.SaveChanges();
                        return PartialView("_Allfeedbacks");
                    }

                    return PartialView(feeedback);
                }*/


    }
}
