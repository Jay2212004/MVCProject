using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Service
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly ApplicationDbContext db;
        public ManagerRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Manager m)
        {
            db.Manager.Add(m);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var manager = db.Manager.Find(id);
            if (manager != null)
            {
                db.Manager.Remove(manager);
                db.SaveChanges();
            }
        }

        public List<Manager> GetAll()
        {
            return db.Manager.ToList();
        }

        public Manager GetById(int id)
        {
            return db.Manager.Find(id);
        }

        public void Update(Manager m)
        {
            db.Manager.Update(m);
            db.SaveChanges();
        }
    }
}
