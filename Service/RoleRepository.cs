using MVC_Task.Data;
using MVC_Task.Models;
using MVC_Task.Repository;

namespace MVC_Task.Service
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;

        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Role role)
        {
            _db.Role.Add(role);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _db.Role.Find(id);
            if (role != null)
            {
                _db.Role.Remove(role);
                _db.SaveChanges();
            }
        }

        public List<Role> GetAll()
        {
            return _db.Role.ToList();
        }

        public Role GetById(int id)
        {
            return _db.Role.FirstOrDefault(r => r.RoleId == id);
        }

        public void Update(Role role)
        {
            _db.Role.Update(role);
            _db.SaveChanges();
        }
    }
}
