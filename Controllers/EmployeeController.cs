using HRRepository.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRRepository.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Route("~/")]
        public ActionResult Index()
        {
            var modal = new Employee().GetEmployees();
            return View(modal);
        }
        [Route("~/employee/get")]
        public ActionResult GetEmployeeList()
        {
            var modal = new Employee().GetEmployees();
            return PartialView("_EmployeeList", modal);
        }

        [Route("~/employee/save")]
        [HttpPost]
        public ActionResult SaveEmployees(FormCollection formCollection)
        {

            var name = formCollection["name"];
            var gender = formCollection["gender"];
            var age = formCollection["age"];

            // Validate all fields before save
            var employee = new Employee
            {
                FullName = name,
                Age = Convert.ToInt32(age),
                Gender = gender
            };

            employee.SaveEmployee();

            return Content("1");
        }
    }
}