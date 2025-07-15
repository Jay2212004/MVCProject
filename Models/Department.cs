using System.ComponentModel.DataAnnotations;

namespace MVC_Task.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public List<Emp> emps {  get; set; }
        public List<Manager> manager{ get; set; }

    } 

}
