using System.Collections.Generic;
using CommonLayer.MODEL;
using ManagerLayer.INTERFACES;
using Microsoft.AspNetCore.Mvc;

namespace Employee2MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager manager;

        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }

        public IActionResult GetAllEmployee()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = manager.GetAllEmployee();

            return View(lstEmployee);
        }

        [HttpGet]
        //[Route("Add")]
        public IActionResult AddData()
        {
            return View();
        }

        [HttpPost]
       // [Route("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddData([Bind] AddEmployee employee)
        {
            if (ModelState.IsValid)
            {
                manager.AddEmployee(employee);
                return RedirectToAction("GetAllEmployee");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = manager.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                manager.UpdateEmployee(employee);
                return RedirectToAction("GetAllEmployee");
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = manager.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            manager.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployee");
        }
    }
}
