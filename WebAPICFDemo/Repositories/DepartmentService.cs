using WebAPICFDemo.Data;
using WebAPICFDemo.Models;

namespace WebAPICFDemo.Repositories
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly Context _context;
        public DepartmentService(Context context)
        {
            _context = context;
        }
        public string AddNewDepartment(Department department)
        {
            if (department == null)
            {
                return null;
            }
            _context.Departments.Add(department);
            _context.SaveChanges();
            return $"Added Department with DepartmentID : {department.DepartmentID}";
        }

        public string DeleteDepartment(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var departmentToRemove = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
            if(departmentToRemove == null)
            {
                return null;
            }
            _context.Departments.Remove(departmentToRemove);
            _context.SaveChanges();
            return $"Removed Department with DepartmentID : {departmentToRemove.DepartmentID}";
        }

        public List<Department> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();
            if(departments == null)
            {
                return null;
            }
            return departments;
        }

        public Department GetDepartmentByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var department = _context.Departments.FirstOrDefault(d => d.DepartmentID == id);
            return department;
        }

        public string UpdateDepartment(Department department)
        {
            var existingDepartment = _context.Departments.FirstOrDefault(x => x.DepartmentID == department.DepartmentID);
            if (existingDepartment == null)
            {
                return null;
            }
            existingDepartment.DepartmentName = department.DepartmentName;
            existingDepartment.DepartmentHead = department.DepartmentHead;
            _context.Entry(existingDepartment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return $"Updated Department with DepartmentID : {department.DepartmentID}";
        }
    }
}
