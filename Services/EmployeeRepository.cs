using EmployeesTable.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesTable.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext _context;
        public EmployeeRepository(DBContext context)
        {
            _context = context;
        }
        public ActionResult<Employee> Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.addresses).ToList();

        }

        public ActionResult<Employee> GetById(int id)
        {
            var emp = _context.Employees.Include(e => e.addresses).FirstOrDefault(e => e.id == id);
            if (emp == null)
            {
                return new StatusCodeResult(404);
            }
            else
                return emp;
        }

        ActionResult IEmployeeRepository.Delete(int id)
        {
            var emp = GetById(id).Value;
            if (emp == null)
            {
                return new StatusCodeResult(404);
            }
            else
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return new StatusCodeResult(200);
            }

        }

        ActionResult<Employee> IEmployeeRepository.Update(int id, Employee employee)
        {
            var oldemp = GetById(id).Value;
            if (oldemp == null)
            {
                return new StatusCodeResult(404);
            }
            else
            {
                oldemp.name = employee.name;
                oldemp.addresses = employee.addresses;
                oldemp.age = employee.age;
                _context.SaveChanges();
                return oldemp;
            }
        }
    }
}
