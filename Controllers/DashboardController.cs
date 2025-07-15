using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Data;
using MVC_Task.Models;

namespace MVC_Task.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext db;

        public DashboardController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Authorize(Roles = "admin")]
        public IActionResult AdminDashboard()
        {
            var combine = new Combine
            {
                emps = db.employee.ToList(),
                manager = db.Manager.ToList(),
                role = db.Role.ToList(),
                dept = db.Department.ToList()
            };

            ViewBag.LoggedInEmail = HttpContext.Session.GetString("email"); // Optional

            return View(combine);
        }

        [Authorize(Roles = "user")]
        public IActionResult UserDashboard()
        {
            int empId = HttpContext.Session.GetInt32("EmpId") ?? 0;
            var documents = db.Document.Where(d => d.EmpId == empId).ToList();

            return View(documents);
        }
    }
}
