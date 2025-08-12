using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRecordLINQVersion.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordLINQVersion.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeInterface objemployee;

        //Constructor
        public EmployeeController(IEmployeeInterface accesslayer)
        {
            this.objemployee = accesslayer;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Posts form Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {

                objemployee.AddEmployee(employee);

            }
            return RedirectToAction("Create");
            //return RedirectToAction(nameof(Details), new { id = emp.ID });
           //return View();
        }

        public IActionResult FilteredResults()
        {
            //dynamic filteredResult;
            //dynamic filteredResult = new ExpandoObject();
            var filteredResult = (objemployee.getAllEmployees()
                                 .Select(x => new ResultSetsViewModel { Name=x.Name, Gender=x.Gender,Dept= x.Department, City=x.City })
                                 .Where(x => x.Gender == "Male")).ToList();
            //ViewBag.MyFilteredResults = filteredResult;
            return View(filteredResult);
        }

        //Loads Employee Details
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.getAllEmployees().ToList();

            return View(lstEmployee);
        }


        [HttpGet]
        public IActionResult Edit(int id, [Bind] Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            else
            {
                employee = objemployee.GetEmployeeDetails(id);
                //ViewBag.Employee = employee;
                //var viewbags = ViewBag.Employee;
                return View(employee);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.UpdateEmployee(employee);
                //return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Details(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }

            else
            {
                employee = objemployee.GetEmployeeDetails(id);
                //ViewBag.Employee = employee;
                //var viewbags = ViewBag.Employee;
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeDetails(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        //[HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objemployee.DeleteEmployeeDetails(id);
            return RedirectToAction("Index");
        }
    }
}