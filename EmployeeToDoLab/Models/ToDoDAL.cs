using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Models
{
    public class ToDoDAL
    {
        //Getting a single todo - Read
        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from todos where id=" + id;
                connect.Open();
                ToDo todo = connect.Query<ToDo>(sql).First();
                connect.Close();

                return todo;
            }
        }
        //Getting a list of todos - Read
        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from todos";
                connect.Open();
                List<ToDo> todos = connect.Query<ToDo>(sql).ToList();
                connect.Close();

                return todos;
            }
        }
        //Create todo
        public void CreateToDo(ToDo td)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "insert into todos " +
                    $"values(0, '{td.Name}', '{td.Description}', {td.AssignedTo}, {td.HoursNeeded}, {td.IsCompleted});";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        //Update todo
        public void UpdateToDo(ToDo td)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "update todos " +
                    $"set Name='{td.Name}', Description='{td.Description}', AssignedTo={td.AssignedTo}, HoursNeeded ={td.HoursNeeded}, IsCompleted={td.IsCompleted} " +
                    $"where id={td.Id};";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
        //Deleting todo
        public void DeleteToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "delete from todos where id=" + id;
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }


    }
}
