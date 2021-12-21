using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ToDoId { get; set; }
        public Employee Employee { get; set; }
        public ToDo ToDo { get; set; }        
    }
}
