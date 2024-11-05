using WebAPICFDemo.Data;
using WebAPICFDemo.Models;
namespace WebAPICFDemo.Repositories
{
    public class EmployeeService:IEmployeeServices
    {
        private readonly Context _context;
        public EmployeeService(Context context)
        {
            _context = context;
        }

        public string AddNewEmployee(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return $"Added Employee with EmployeeID : {employee.EmployeeID}";
        }

        public string DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var employeeToRemove = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if(employeeToRemove == null)
            {
                return null;
            }
            _context.Employees.Remove(employeeToRemove);
            _context.SaveChanges();
            return $"Removed Employee with EmployeeID : {employeeToRemove.EmployeeID}";
        }

        public List<Employee> GetAllEmployeesFromDepartment(int departmentID)
        {
            var employees = _context.Employees.Where(e => e.DepartmentID == departmentID).ToList();
            foreach (var employee in employees) {
                Console.WriteLine(employee);
            }
            if(employees == null)
            {
                return null;
            }
            return employees;
        }

        public Employee GetEmployeeByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if(employee == null)
            {
                return null;
            }
            return employee;
        }
        public string UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(x => x.EmployeeID == employee.DepartmentID);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Gender = employee.Gender;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.Email = employee.Email;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentID = employee.DepartmentID;
            _context.Entry(existingEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return $"Updated Employee with EmployeeID : {employee.EmployeeID}";
        }
    }
}
