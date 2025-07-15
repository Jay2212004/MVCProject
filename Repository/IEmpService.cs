using MVC_Task.Models;


namespace MVC_Task.Repository
{
    public interface IEmpService
    {
        void AddEmp(Emp e);
        List<Emp> displayEmp();
        void DeleteEmp(int id);

        Emp findEmpById(int id);
        void UpdateEmpDetails(Emp e);
    }
}
