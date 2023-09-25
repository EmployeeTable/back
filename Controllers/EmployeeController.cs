using EmployeesTable.DTO;
using EmployeesTable.Models;
using EmployeesTable.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeesTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeAddressDTO> Get()
        {
            var employees = _employeeService.GetAll();
            return employees;
        }


        [HttpGet("{id}")]
        public ActionResult<EmployeeAddressDTO> Get(int id)
        {
            var employee = _employeeService.GetById(id);
            return employee;
        }


        [HttpPost]
        public IActionResult Post([FromBody] EmployeeAddressDTO employee)
        {
            _employeeService.Add(employee);
            return Ok(employee);
        }


        [HttpPut("{id}")]
        public ActionResult<EmployeeAddressDTO> Put(int id,  EmployeeAddressDTO emp)
        {
            return _employeeService.Update(id, emp);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _employeeService.Delete(id);

        }
    }
}
