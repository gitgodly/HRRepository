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

    }
}