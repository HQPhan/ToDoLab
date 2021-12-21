using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeToDoLab.Models
{
    public class AssignmentDAL
    {
        public void CreateAssignment(Assignment a)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"insert into assignment values(0,{a.EmployeeId}, {a.ToDoId})";
                connect.Open();
                connect.Query<Assignment>(sql);
                connect.Close();
            }
        }

        //Update an assignment
        public void UpdateAssignment(Assignment a)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "update assignment " +
                    $"set EmployeeId={a.EmployeeId}, ToDoId={a.ToDoId} " +
                    $"where id={a.Id};";
                connect.Open();
                connect.Query<Assignment>(sql);
                connect.Close();
            }

        }
        //Deleting an assignment
        public void DeleteAssignment(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "delete from assignment where id=" + id;
                connect.Open();
                connect.Query<Assignment>(sql);
                connect.Close();
            }
        }
    }
}
