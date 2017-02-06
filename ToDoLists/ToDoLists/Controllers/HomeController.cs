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
            var tdl = unitOfWork.ListRepository.GetAll();
            return View(tdl);
        }

        public ActionResult Record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Record(TodoList listRecord)
        {   
            if (ModelState.IsValid)
            {
                unitOfWork.ListRepository.Create(listRecord);
                unitOfWork.Save();
                return View("Message");
            }
                return View(listRecord);
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var del = unitOfWork.ListRepository.Get(id);
            if (del == null)
            {
                return HttpNotFound();
            }
            return View(del);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var del = unitOfWork.ListRepository.Get(id);
            if (del == null)
            {
                return HttpNotFound();
            }
            unitOfWork.ListRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            TodoList up = unitOfWork.ListRepository.Get(id);
            if (up == null)
                return HttpNotFound();
            return View(up);
        }

        [HttpPost]
        public ActionResult Edit(TodoList up)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ListRepository.Update(up);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(up);
        }
        public ActionResult Message()
        {
            return View();
        }
    }
}