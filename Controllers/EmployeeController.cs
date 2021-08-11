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

        [Route("~/employee/save")]
        public ActionResult SaveEmployees(FormCollection formCollection)
        {

            return View();
        }


    }
}