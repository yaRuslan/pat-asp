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
            ListContext list = new ListContext(); //-
            var tdl = list.TodoLists.Where(c => c.List_id < 1000);//-
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
            }
            return View("Message", listRecord);
        }
    }
}