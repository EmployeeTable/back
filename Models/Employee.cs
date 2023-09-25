using EmployeesTable.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesTable.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = ValidationMessages.NameLettersOnly)]
        public string name { set; get; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Range(20, int.MaxValue, ErrorMessage = ValidationMessages.AgeRange)]
        public int age { set; get; }

        public virtual ICollection<Address> addresses { set; get; }

    }
}
