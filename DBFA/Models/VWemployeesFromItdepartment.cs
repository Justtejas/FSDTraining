using System;
using System.Collections.Generic;

namespace DBFA.Models
{
    public partial class VWemployeesFromItdepartment
    {
        public string EmployeeName { get; set; } = null!;
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }
}
