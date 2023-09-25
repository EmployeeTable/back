using EmployeesTable.DTO;
using EmployeesTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesTable.Services
{
    public interface IEmployeeService
    {
        ActionResult<EmployeeAddressDTO> GetById(int id);
        IEnumerable<EmployeeAddressDTO> GetAll();
        EmployeeAddressDTO Add(EmployeeAddressDTO employee);
        ActionResult<EmployeeAddressDTO> Update(int id, EmployeeAddressDTO employee);
        ActionResult Delete(int id);
    }
}
