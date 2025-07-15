

using MVC_Task.Models;

namespace MVC_Task.Repository
{
    public interface IDocumentRepo
    {
        void Upload(Documents doc);
        List<Documents> GetAllWithEmp();
    }

}
