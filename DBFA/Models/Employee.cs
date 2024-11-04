using System;
using System.Collections.Generic;

namespace DBFA.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeGender { get; set; } = null!;
        public DateTime EmployeeDob { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
