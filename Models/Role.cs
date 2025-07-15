using System.ComponentModel.DataAnnotations;

namespace MVC_Task.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
