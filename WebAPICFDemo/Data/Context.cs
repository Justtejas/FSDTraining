using Microsoft.EntityFrameworkCore;
using WebAPICFDemo.Models;
namespace WebAPICFDemo.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
