using Microsoft.AspNetCore.Mvc;
using WebAPICFDemo.Models;
using WebAPICFDemo.Repositories;

namespace WebAPICFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _services;
        public DepartmentController(IDepartmentServices services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = _services.GetAllDepartments();
            if (departments == null || departments.Count == 0)
            {
                return NotFound("There are no Departments");
            }
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentByID(int id)
        {
            Department department = _services.GetDepartmentByID(id);
            if(department == null)
            {
                return NotFound($"Department with DepartmentID: {id} not found");
            }
            return Ok(department);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            string status  = _services.AddNewDepartment(department);
            if(status == null)
            {
                return BadRequest("Invalid Department Data");
            }
            return Ok(status);
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            string status = _services.UpdateDepartment(department);
            if(status == null)
            {
                return BadRequest("Invalid Department Data");
            }
            return Ok(status);
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            string status = _services.DeleteDepartment(id);
            if(status == null)
            {
                return NotFound($"Department with DepartmentID: {id} not found");
            }
            return Ok(status);
        }
    }
}
