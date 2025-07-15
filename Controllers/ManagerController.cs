using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    [Authorize(Roles = "admin")] 
    public class ManagerController : Controller
    {
        private readonly IManagerRepo repo;

        public ManagerController(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var data = repo.GetAll();
            return View(data);
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager m)
        {
            repo.Add(m);
            TempData["success"] = "Manager added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult EditManager(int id)
        {
            var manager = repo.GetById(id);
            if (manager == null)
                return NotFound();

            return View(manager);
        }

        [HttpPost]
        public IActionResult EditManager(Manager m)
        {
            repo.Update(m);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteManager(int id)
        {
            repo.Delete(id);
            TempData["error"] = "Manager Deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
