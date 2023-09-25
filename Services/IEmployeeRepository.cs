using EmployeesTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesTable.Services
{
    public interface IEmployeeRepository
    {
        ActionResult<Employee> GetById(int id);
        IEnumerable<Employee> GetAll();
        ActionResult<Employee> Add(Employee employee);
        ActionResult<Employee> Update(int id, Employee employee);
        ActionResult Delete(int id);

    }
}
