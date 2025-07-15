using Microsoft.EntityFrameworkCore;
using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Service
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly ApplicationDbContext db;
        public DocumentRepo(ApplicationDbContext db) { this.db = db; }

        public void Upload(Documents doc)
        {
            db.Document.Add(doc);
            db.SaveChanges();
        }
        public List<Documents> GetAllWithEmp()
        {
            return db.Document.Include(d => d.Emp).ToList();
        }

        
    }
}