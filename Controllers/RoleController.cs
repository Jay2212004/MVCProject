using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var roles = _repo.GetAll();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _repo.Add(role);
            TempData["success"] = "Role added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult EditRole(int id)
        {
            var role = _repo.GetById(id);
            return View(role);
        }

        [HttpPost]
        public IActionResult EditRole(Role role)
        {
            _repo.Update(role);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRole(int id)
        {
            _repo.Delete(id);
            TempData["error"] = "Role Deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
