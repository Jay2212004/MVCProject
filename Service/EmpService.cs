using Microsoft.EntityFrameworkCore;
using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Service
{
    public class EmpService : IEmpService
    {
        ApplicationDbContext db;
        public EmpService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddEmp(Emp e)
        {
            db.employee.Add(e);
            db.SaveChanges();
        }

        public List<Emp> displayEmp()
        {
            var data = db.employee
                .Include(e => e.Role)
                .Include(e => e.Department)
                .Include(e => e.manager)
                .ToList();

            return data;
        }


        public void DeleteEmp(int id)
        {
            var d = db.employee.Find(id);
            db.employee.Remove(d);
            db.SaveChanges();
        }

        public Emp findEmpById(int id)
        {
            var data = db.employee.Find(id);
            return data;
        }

        public void UpdateEmpDetails(Emp e)
        {
            db.employee.Update(e);
            db.SaveChanges();
        }
    }
}
