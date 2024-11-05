using DemoWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        static List<Employee> employees;
        static EmployeeController()
        {
            employees = new List<Employee>()
            {
                new (){EmployeeID = 1, Designation = "Trainee", DOJ = DateTime.Parse("2024-11-08 00:00:00"), Name = "Varun", Salary=50000m},
                new (){EmployeeID = 2, Designation = "Trainee", DOJ = DateTime.Parse("2024-11-08 00:00:00"), Name = "Sanskar", Salary=50000m},
                new (){EmployeeID = 3, Designation = "Trainee", DOJ = DateTime.Parse("2024-11-08 00:00:00"), Name = "Aniket", Salary=50000m},
                new (){EmployeeID = 4, Designation = "Trainee", DOJ = DateTime.Parse("2024-11-08 00:00:00"), Name = "Yash", Salary=50000m},
                new (){EmployeeID = 5, Designation = "Trainee", DOJ = DateTime.Parse("2024-11-08 00:00:00"), Name = "Prathmesh", Salary=50000m},
            };
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            if(employees.Count > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            if( employee == null)
            {
                return BadRequest();
            }
            else
            {
                employees.Add(employee);
            }
            return CreatedAtAction(nameof(GetAllEmployees),new {id = employee.EmployeeID, message = $"Added Emloyee with EmployeeID : {employee.EmployeeID}"});
        }
        [HttpPut]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if(id != employee.EmployeeID)
            {
                return BadRequest("Id MisMatch");
            }
            var existingEmployee = employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.DOJ = employee.DOJ;
            existingEmployee.Salary = employee.Salary;
            return Ok(existingEmployee);
        }
        [HttpPatch]
        public IActionResult PatchEmployee(int id, Employee employee)
        {
            var existingEmployee = employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if (existingEmployee == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(employee.Name))
            {
                existingEmployee.Name = employee.Name;
            }
            if (!string.IsNullOrEmpty(employee.Designation))
            {
                existingEmployee.Designation = employee.Designation;
            }
            if (employee.DOJ != default)
            {
                existingEmployee.DOJ = employee.DOJ;
            }
            if (employee.Salary > 0)
            {
                existingEmployee.Salary = employee.Salary;
            }
            return Ok(existingEmployee);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeToRemove = employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            if (employeeToRemove == null)
            {
                return NotFound($"Employee with id : {id} does not exist.");
            }
            employees.Remove(employeeToRemove);
            return Ok($"Removed Employee with EmployeeID: {employeeToRemove.EmployeeID}");
        }
    }
}
