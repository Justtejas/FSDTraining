using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPICFDemo.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        [Key]
        [DisplayName("Department ID")]
        public int DepartmentID { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Head")]
        public string DepartmentHead { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
