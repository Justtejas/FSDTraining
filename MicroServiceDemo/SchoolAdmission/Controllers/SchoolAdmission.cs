using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Models;
namespace SchoolAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolAdmission : Controller
    {
        static List<StudentAdmissionDetail> studentAdmissionList = new();

        [HttpGet]
        public List<StudentAdmissionDetail> GetStudentDetails()
        {
            StudentAdmissionDetail admission1 = new ();
            StudentAdmissionDetail admission2 = new ();
            StudentAdmissionDetail admission3 = new ();

            admission1.StudentID = 101;
            admission1.StudentName = "Amol";
            admission1.StudentClass = "C++";
            admission1.DateofJoining = DateTime.Now;
            admission2.StudentID = 102;
            admission2.StudentName = "Tejas";
            admission2.StudentClass = "C#";
            admission2.DateofJoining = DateTime.Now;
            admission3.StudentID = 103;
            admission3.StudentName = "Parit";
            admission3.StudentClass = "Java";
            admission3.DateofJoining = DateTime.Now;
            studentAdmissionList.Add(admission1);
            studentAdmissionList.Add(admission2);
            studentAdmissionList.Add(admission3);
            return studentAdmissionList;
        }
    }
}
