namespace CodeFirstApproachDemo.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
