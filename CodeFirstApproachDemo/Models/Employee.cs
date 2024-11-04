namespace CodeFirstApproachDemo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
