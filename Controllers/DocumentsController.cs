using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Controllers
{
    [Authorize(Roles = "admin")] 
    public class DocumentsController : Controller
    {
        private readonly IDocumentRepo repo;
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment env;

        public DocumentsController(IDocumentRepo repo, ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.db = db;
            this.env = env;
        }

        public IActionResult Upload()
        {
            ViewBag.emps = new SelectList(
                db.employee.Include(e => e.Role).Where(e => e.Role.RoleName.ToLower() == "user").ToList(),
                "eid", "ename");

            return View();
        }

        [HttpPost]
        public IActionResult Upload(Documents model, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string folder = Path.Combine(env.WebRootPath, "docs");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string filePath = Path.Combine(folder, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                model.FileName = file.FileName;
                model.FilePath = "/docs/" + file.FileName;

                repo.Upload(model);
            }

            TempData["success"] = "Document added successfully!";
            return RedirectToAction("Upload_List");
        }

        public IActionResult Upload_List()
        {
            var data = repo.GetAllWithEmp();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
            var doc = db.Document.Find(id);
            if (doc == null) return NotFound();

            ViewBag.emps = new SelectList(db.employee.ToList(), "eid", "ename", doc.EmpId);
            return View(doc);
        }

        [HttpPost]
        public IActionResult Edit(Documents model, IFormFile file)
        {
            var existing = db.Document.Find(model.DocId);
            if (existing == null) return NotFound();

            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(env.WebRootPath, "docs", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                existing.FileName = file.FileName;
                existing.FilePath = "/docs/" + file.FileName;
            }

            existing.EmpId = model.EmpId;
            db.SaveChanges();

            return RedirectToAction("Upload_List");
        }

        public IActionResult Delete(int id)
        {
            var doc = db.Document.Find(id);
            if (doc == null) return NotFound();

            var path = Path.Combine(env.WebRootPath, "docs", doc.FileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            db.Document.Remove(doc);
            db.SaveChanges();

            TempData["error"] = "Document Deleted successfully!!";
            return RedirectToAction("Upload_List");
        }

        public IActionResult Download(int id)
        {
            var doc = db.Document.FirstOrDefault(d => d.DocId == id);
            if (doc == null) return NotFound();

            var filePath = Path.Combine(env.WebRootPath, "docs", doc.FileName);
            var mimeType = "application/octet-stream";
            return PhysicalFile(filePath, mimeType, doc.FileName);
        }
    }
}
