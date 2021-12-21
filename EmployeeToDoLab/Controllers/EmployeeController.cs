using EmployeeToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL eDB = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> employees = eDB.GetEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                eDB.CreateEmployee(employee);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(employee);
            }
        }

        public IActionResult Details(int id)
        {
            Employee employee = eDB.GetEmployee(id);
            return View(employee);
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee employee = eDB.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            eDB.UpdateEmployee(employee);
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Delete(int id)
        {
            Employee employee = eDB.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            eDB.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
