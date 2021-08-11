using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRRepository.Models
{
    public class Employee
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Employee> Employees { get; set; }

        public List<Employee> GetEmployees()
        {
            Employees = new List<Employee>();

            using (var con = new SqlConnection(DbContext.GetConnectionString()))
            {
                var cmd = new SqlCommand("EmployeesSelect", con);
                con.Open();
                var dreader = cmd.ExecuteReader();
                if(dreader.HasRows)
                {
                    while(dreader.Read())
                    {
                        Employees.Add(new Employee()
                        {
                            ID = dreader[0].ToString(),
                            FullName = dreader[1].ToString(),
                            Age = Convert.ToInt32(dreader[2]),
                            Gender = dreader[3].ToString(),
                        });
                    }
                }
            }
            return Employees;
        }

        public bool SaveEmployee()
        {
            using (var con = new SqlConnection(DbContext.GetConnectionString()))
            {
                var cmd = new SqlCommand("EmployeesInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", FullName);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@AGE", Age);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

        }

    }
}