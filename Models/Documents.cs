
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task.Models
{
    public class Documents
    {
        [Key]
        public int DocId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("Emp")]
        public int EmpId { get; set; }
        public Emp Emp { get; set; }
    }
}