using MVC_Task.Models;

namespace MVC_Task.Repository
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        void Add(Department d);
        Department GetById(int id);
        void Update(Department d);
        void Delete(int id);
    }

}
