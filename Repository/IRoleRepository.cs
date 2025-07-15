using System.Collections.Generic;
using MVC_Task.Models;

namespace MVC_Task.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Add(Role role);
        void Update(Role role);
        void Delete(int id);
    }
}
