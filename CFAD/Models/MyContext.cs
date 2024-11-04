using Microsoft.EntityFrameworkCore;

namespace CFAD.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
