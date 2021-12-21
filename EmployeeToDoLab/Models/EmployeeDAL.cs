using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Models
{
    public class EmployeeDAL
    {
        //Getting a single employee - Read
        public Employee GetEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from employee where id=" + id;
                connect.Open();
                Employee employee = connect.Query<Employee>(sql).First();
                connect.Close();

                return employee;
            }
        }
        //Getting a list of employee - Read
        public List<Employee> GetEmployees()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from employee";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(sql).ToList();
                connect.Close();

                return employees;
            }
        }
        //Create an employee
        public void CreateEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "insert into employee " +
                    $"values(0, '{e.Name}', {e.Hours}, '{e.Title}');";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }
        //Update an employee
        public void UpdateEmployee(Employee e)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "update employee " +
                    $"set Name='{e.Name}', Hours={e.Hours}, Title='{e.Title}' " +
                    $"where id={e.Id};";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }

        }
        //Deleting an employee
        public void DeleteEmployee(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "delete from employee where id=" + id;
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }
    }
}
