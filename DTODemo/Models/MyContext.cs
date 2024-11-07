using Microsoft.EntityFrameworkCore;

namespace DTODemo.Models
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
