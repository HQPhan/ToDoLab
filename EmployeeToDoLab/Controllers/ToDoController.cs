using EmployeeToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Controllers
{
    public class ToDoController : Controller
    {
        ToDoDAL tdDB = new ToDoDAL();
        public IActionResult Index()
        {
            List<ToDo> todos = tdDB.GetToDos();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                tdDB.CreateToDo(todo);
                return RedirectToAction("Index", "ToDo");
            }
            else
            {
                return View(todo);
            }
        }

        public IActionResult Details(int id)
        {
            ToDo todo = tdDB.GetToDo(id);
            return View(todo);
        }

        public IActionResult UpdateToDo(int id)
        {
            ToDo todo = tdDB.GetToDo(id);
            return View(todo);
        }
        [HttpPost]
        public IActionResult UpdateToDo(ToDo todo)
        {
            tdDB.UpdateToDo(todo);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult Delete(int id)
        {
            ToDo todo = tdDB.GetToDo(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult DeleteToDo(int id)
        {
            tdDB.DeleteToDo(id);
            return RedirectToAction("Index", "ToDo");
        }
    }
}
