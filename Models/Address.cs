using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesTable.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string description { set; get; }
        [ForeignKey("employee")]
        public int employee_id { set; get; }

        public virtual Employee employee { get; set; }
    }
}
