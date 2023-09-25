using EmployeesTable.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeesTable.DTO
{
    public class AddressDTo
    {
        [Required(ErrorMessage = ValidationMessages.Required)]
        public string description { set; get; }
    }
}
