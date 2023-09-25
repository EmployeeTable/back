using AutoMapper;
using EmployeesTable.DTO;
using EmployeesTable.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesTable.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employee;
        public EmployeeService(IMapper mapper, IEmployeeRepository employee)
        {
            _mapper = mapper;
            _employee = employee;
        }
        public EmployeeAddressDTO Add(EmployeeAddressDTO employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            _employee.Add(emp);
            return _mapper.Map<EmployeeAddressDTO>(emp);
        }

        public ActionResult Delete(int id)
        {
            return _employee.Delete(id);
        }

        public IEnumerable<EmployeeAddressDTO> GetAll()
        {
            List<Employee> employees = _employee.GetAll().ToList();
            var employeeAddressDTOs = employees.Select(employee => _mapper.Map<EmployeeAddressDTO>(employee));
            return employeeAddressDTOs;
        }



        public ActionResult<EmployeeAddressDTO> GetById(int id)
        {
            var emp = _employee.GetById(id).Value;
            if (emp is Employee)
            {
                var emp2 = _mapper.Map<EmployeeAddressDTO>(emp);
                return emp2;
            }
            else
                return new StatusCodeResult(404);
        }

        public ActionResult<EmployeeAddressDTO> Update(int id, EmployeeAddressDTO employee)
        {
            var emp = _mapper.Map<Employee>(employee);
            var emp2 = _employee.Update(id, emp);

            if (emp2.Value is Employee)
            {
                var updatedemp = _mapper.Map<EmployeeAddressDTO>(emp2.Value);
                return updatedemp;
            }
            else
            {
                return new StatusCodeResult(404);
            }
        }
    }
}
