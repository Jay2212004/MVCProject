using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo repo;

        public AccountController(IAccountRepo repo)
        {
            this.repo = repo;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            var emp = repo.ValidateUser(email, password);

            if (emp == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, emp.ename),
                new Claim(ClaimTypes.Email, emp.email),
                new Claim(ClaimTypes.Role, emp.Role.RoleName.ToLower())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

     
            HttpContext.Session.SetString("EmpName", emp.ename);
            HttpContext.Session.SetString("Role", emp.Role.RoleName.ToLower());
            HttpContext.Session.SetInt32("EmpId", emp.eid);
            HttpContext.Session.SetString("email", emp.email);

           
            if (emp.Role.RoleName.ToLower() == "admin")
                return RedirectToAction("AdminDashboard", "Dashboard");
            else
                return RedirectToAction("UserDashboard", "Dashboard");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

          
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookie in storedCookies)
            {
                Response.Cookies.Delete(cookie);
            }

            
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
