using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;
using MVC_Task.Data;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmpController : Controller
    {
        private readonly IEmpService service;
        private readonly ApplicationDbContext db;

        public EmpController(IEmpService service, ApplicationDbContext db)
        {
            this.service = service;
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = service.displayEmp();
            ViewBag.LoggedInEmail = HttpContext.Session.GetString("email");
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(string str)
        {
            var data = string.IsNullOrEmpty(str)
                ? service.displayEmp()
                : service.displayEmp().Where(e => e.ename.Contains(str) || e.email.Contains(str) || e.esalary.ToString().Contains(str)).ToList();

            ViewBag.LoggedInEmail = HttpContext.Session.GetString("email");
            return View(data);
        }

        public IActionResult AddEmp()
        {
            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            ViewBag.roles = new SelectList(db.Role.ToList(), "RoleId", "RoleName");
            ViewBag.departments = new SelectList(db.Department.ToList(), "DeptId", "DeptName");

            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            ViewBag.roles = new SelectList(db.Role.ToList(), "RoleId", "RoleName");
            ViewBag.departments = new SelectList(db.Department.ToList(), "DeptId", "DeptName");

            if (ModelState.IsValid)
            {
                service.AddEmp(e);
                TempData["success"] = "Employee added successfully!";
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public IActionResult DelEmp(int id)
        {
            service.DeleteEmp(id);
            TempData["error"] = "Employee deleted successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult EditEmp(int id)
        {
            var emp = service.findEmpById(id);
            if (emp == null) return NotFound();

            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            ViewBag.roles = new SelectList(db.Role.ToList(), "RoleId", "RoleName");
            ViewBag.departments = new SelectList(db.Department.ToList(), "DeptId", "DeptName");

            return View(emp);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            ViewBag.roles = new SelectList(db.Role.ToList(), "RoleId", "RoleName");
            ViewBag.departments = new SelectList(db.Department.ToList(), "DeptId", "DeptName");

            if (ModelState.IsValid)
            {
                service.UpdateEmpDetails(e);
                return RedirectToAction("Index");
            }

            return View(e);
        }
    }
}
