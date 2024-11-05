using Microsoft.AspNetCore.Mvc;
using WebAPICFDemo.Models;
using WebAPICFDemo.Repositories;
namespace WebAPICFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices services)
        {
            _employeeServices = services;
        }
        [HttpGet]
        public IActionResult GetAllEmployeesFromDepartment(int id)
        {
            var employees = _employeeServices.GetAllEmployeesFromDepartment(id);
            if (employees == null || employees.Count == 0)
            {
                return NotFound("There are no Employees in this Department");
            }
            return Ok(employees);
        }
        [HttpGet("employee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _employeeServices.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound($"Employee with EmployeeID: {id} not found");
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            string status = _employeeServices.AddNewEmployee(employee);
            if (status == null)
            {
                return BadRequest("Invalid Employee Data");
            }
            return Ok(status);
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            string status = _employeeServices.UpdateEmployee(employee);
            if (status == null)
            {
                return BadRequest("Invalid Employee Data");
            }
            return Ok(status);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            string status = _employeeServices.DeleteEmployee(id);
            if (status == null)
            {
                return NotFound($"Employee with EmployeeID: {id} not found");
            }
            return Ok(status);
        }
    }
}
