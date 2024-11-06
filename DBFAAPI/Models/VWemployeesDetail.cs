using System;
using System.Collections.Generic;

namespace DBFAAPI.Models
{
    public partial class VWemployeesDetail
    {
        public string EmployeeName { get; set; } = null!;
        public int EmployeeId { get; set; }
        public DateTime EmployeeDob { get; set; }
        public string EmployeeGender { get; set; } = null!;
        public int? DepartmentId { get; set; }
    }
}
