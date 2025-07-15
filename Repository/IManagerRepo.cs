using System.Collections.Generic;
using MVC_Task.Models;

namespace MVC_Task.Repository
{
    public interface IManagerRepo
    {
        void Add(Manager m);
        void Update(Manager m);
        void Delete(int id);
        Manager GetById(int id);
        List<Manager> GetAll();
    }
}
