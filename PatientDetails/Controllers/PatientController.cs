using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientDetails.Models;
using PatientDetails.ViewModel;
namespace PatientDetails.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/
       
        [HttpGet]
        public ActionResult Show()
        {
            List<NewPatient> patients = new Dataaccess().SelectPatient();
            return View(new Patientviewmodel(){Patients = patients} );
        }
        public  ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewPatient patient)
        { 
            
            string name = patient.Name;
            string address = patient.Address;
            string contact = patient.Contactno;
            DateTime dob = patient.Dob;
            string city = patient.City;
            new Dataaccess().ExecuteProcess(name,address,contact,dob,city);
            ViewBag.message = "INSERTED SUCCESSFULLY";
            return View("New");
        }
        public ActionResult PatientDetails(int id)
        {

            List<NewPatient> patients = new Dataaccess().Fetch(id);
            return PartialView(new Patientviewmodel(){Patients = patients});
        }
       
        public ActionResult EditPatient(int id)
        {
            NewPatient patient = new Dataaccess().Update(id);
            if (patient == null)
            {
                return RedirectToAction("Show");
            }
            return View(patient);
        }

        [HttpPost]
        public ActionResult EditPatient(NewPatient patient1)
        {
            if (ModelState.IsValid)
            {
                int k = new Dataaccess().Edit(patient1);
                if (k == 1)
                {
                    TempData["ErrorMessage"] = "Edit Successfully";
                    return RedirectToAction("Show",patient1);
                }
                else
                    return View(patient1);
            }
            return View();
        }

        public ActionResult PatientDelete(int id)
        {
            NewPatient patient1= new Dataaccess().Update(id);
            if(patient1 == null)
            {
                return RedirectToAction("Show");
            }
            else
            {
                return View(patient1);
            }
        }

        [HttpPost]
        public ActionResult PatientDelete(NewPatient patient)
        {
          int k1 = new Dataaccess().Delete(patient.Id);
                if (k1 == 1)
                {
                    TempData["ErrorMessage"] = "Patient Deleted";
                    return RedirectToAction("Show", patient);
                }
                else
                {
                    return View();
                }
        }

    }

    
}
