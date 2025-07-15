// Service/AccountRepo.cs
using Microsoft.EntityFrameworkCore;
using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Service
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ApplicationDbContext db;
        public AccountRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Emp ValidateUser(string email, string password)
        {
            return db.employee.Include(e => e.Role).FirstOrDefault(e => e.email == email && e.password == password);
        }
    }
}
