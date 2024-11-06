using System;
using System.Collections.Generic;

namespace DBFAAPI.Models
{
    public partial class EmployeeAuditTest
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public string? AuditAction { get; set; }
        public DateTime? AuditDate { get; set; }
    }
}
