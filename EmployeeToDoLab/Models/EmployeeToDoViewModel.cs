using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Models
{
    public class EmployeeToDoViewModel
    {
        public List<ToDo> ToDos { get; set; }
        public List<Employee> Employees { get; set; }
        public EmployeeToDoViewModel()
        {
            ToDoDAL tdDAL = new ToDoDAL();
            EmployeeDAL eDAL = new EmployeeDAL();
            ToDos = tdDAL.GetToDos();
            Employees = eDAL.GetEmployees();
        }
    }
}
