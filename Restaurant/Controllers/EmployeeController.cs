using Restaurant.Abstract.IEmployee;
using Restaurant.Business.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController()
        {
            _employee = new employeeServices();
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Orders(string search)
        {
            return View(_employee.Orders(search));
        } 
        
        public ActionResult Details(int id)
        {
            return PartialView(_employee.Details(id));
        } 
        public ActionResult Confirmed(int id)
        {
            _employee.Confirmed(id);
            return RedirectToAction("Orders", "Employee");
        }
    }
}