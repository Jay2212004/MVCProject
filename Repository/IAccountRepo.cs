using MVC_Task.Models;

namespace MVC_Task.Repository
{
    public interface IAccountRepo
    {
        Emp ValidateUser(string email, string password);
    }
}
