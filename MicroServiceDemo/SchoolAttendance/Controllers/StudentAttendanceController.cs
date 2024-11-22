using Microsoft.AspNetCore.Mvc;
using SchoolAttendance.Models;

namespace SchoolAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : Controller
    {
        static List<StudentAttendance> attendanceList;
        [HttpGet]
        public List<StudentAttendance> GetAttendance()
        {
          attendanceList=new List<StudentAttendance> {
                new () { StudentID=101,StudentName="Amol", AttendancePercentage=90},
                new () { StudentID=102,StudentName="Parit", AttendancePercentage=91},
                new () { StudentID=103,StudentName="Akash", AttendancePercentage=92},
                new () { StudentID=104,StudentName="Tejas", AttendancePercentage=93},
          };
            return attendanceList;
        }
    }
}
