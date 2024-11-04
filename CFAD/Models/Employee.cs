using System.ComponentModel.DataAnnotations;

namespace CFAD.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage ="Enter a name")]
        [StringLength(15,ErrorMessage ="Name cannot be more than 15 characters")]
        [MinLength(3,ErrorMessage ="Name needs to be longer than 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter a Gender")]
        [RegularExpression("^(Male|Female|Other)$",ErrorMessage ="Gender must be Male or Female or Other")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Enter a Email")]
        [EmailAddress(ErrorMessage ="Enter a valid email address")]
        public string Email { get; set; }
        public string Designation { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Salary must be a Positive Value")]
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
