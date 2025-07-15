using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_Task.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }

        [Required]
        public string ename { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public double esalary { get; set; }

        [Required]
        public string password { get; set; }

        [ForeignKey("manager")] 
        public int Mid { get; set; }
        public Manager manager { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }
        //public ICollection<Documents> Documents { get; set; }
    }
}
