using WebAPICFDemo.Models;

namespace WebAPICFDemo.Repositories
{
    public interface IDepartmentServices
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentByID(int id);
        string AddNewDepartment(Department department);
        string UpdateDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
