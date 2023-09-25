using EmployeesTable.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeesTable.DTO
{
    public class EmployeeAddressDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = ValidationMessages.NameLettersOnly)]
        public string name { get; set; }
        [Required(ErrorMessage = ValidationMessages.Required)]
        [Range(20, int.MaxValue, ErrorMessage = ValidationMessages.AgeRange)]
        public int age { get; set; }
        [ListLengthValidation(ErrorMessage = ValidationMessages.Required)]
        public virtual ICollection<AddressDTo> addresses { get; set; }
    }
}
