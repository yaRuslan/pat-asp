using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBook.Models;

namespace WebBook.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Record(Patient patientRegInfo)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PatientRepository.Create(patientRegInfo);
                unitOfWork.Save();
            }
            return View("Record_message", patientRegInfo);
        }

    }
}