using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task.Models
{
    public class Manager
    {
        [Key]
        public int Mid { get; set; }
        public string Mname { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public List<Emp> emps { get; set; }
    }
}
