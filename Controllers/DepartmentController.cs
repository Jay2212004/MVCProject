using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    [Authorize(Roles = "admin")] 
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo repo;

        public DepartmentController(IDepartmentRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department d)
        {
            repo.Add(d);
            TempData["success"] = "Department added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Department d)
        {
            repo.Update(d);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            TempData["error"] = "Department Deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
