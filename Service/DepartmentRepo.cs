using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;



namespace MVC_Task.Service
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext db;
        public DepartmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Department> GetAll() => db.Department.ToList();
        public void Add(Department d) { db.Department.Add(d); db.SaveChanges(); }
        public Department GetById(int id) => db.Department.Find(id);
        public void Update(Department d) { db.Department.Update(d); db.SaveChanges(); }
        public void Delete(int id)
        {
            var d = db.Department.Find(id);
            if (d != null)
            {
                db.Department.Remove(d);
                db.SaveChanges();
            }
        }
    }
}