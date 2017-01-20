using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoLists.Models;

namespace ToDoLists.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Home
        public ActionResult Index()
        {
            var tdl = unitOfWork.ListRepository.Get();
            return View(tdl);
        }

        public ActionResult Record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Record(TodoList listRecord)
        {
            if (String.IsNullOrEmpty(listRecord.Task_name))
                ModelState.AddModelError("Task_name", "Введите задачу");
            if (String.IsNullOrEmpty(listRecord.Target_date))
                ModelState.AddModelError("Target_date", "Введите дату");
            if (String.IsNullOrEmpty(listRecord.Complexity))
                ModelState.AddModelError("Complexity", "Введите Сложность");
            if (ModelState.IsValid)
            {
                unitOfWork.ListRepository.Create(listRecord);
                unitOfWork.Save();
                return View("Message", listRecord);
            }
            else
                return View();
            
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
                unitOfWork.ListRepository.Delete(id);
                unitOfWork.Save();
                return RedirectToAction("Index");
        }
        public ActionResult Message()
        {
            return View();
        }
    }
}