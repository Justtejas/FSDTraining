using WebAPICFDemo.Models;

namespace WebAPICFDemo.Repositories
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployeesFromDepartment(int departmentID);
        Employee GetEmployeeByID(int id);
        string AddNewEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
    }
}
