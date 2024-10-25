using Assignments.AssignmentOne;
using Assignments.AssignmentTwo;

namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assignment1 assign1 = new();
            //assign1.AssignmentOne();

            Customer customer = new Customer();
            try
            {
                Console.WriteLine("Enter Name: ");
                Console.Write("> ");
                string name = Console.ReadLine();
                customer.Name = name;
                Console.WriteLine("Enter Email: ");
                Console.Write("> ");
                string email = Console.ReadLine();
                if (Validator.IsValidEmail(email))
                {
                    customer.Email = email;
                }
                else
                {
                    Console.WriteLine("Invalid Email");
                }
                Console.WriteLine("Enter Phone Number: ");
                Console.Write("> ");
                string phoneNumber = Console.ReadLine();
                if (Validator.IsValidPhoneNumber(phoneNumber))
                {
                    customer.PhoneNumber = phoneNumber;
                }
                else
                {
                    Console.WriteLine("Invalid Phone Number");
                }
                Console.WriteLine("Enter Date of Birth: ");
                Console.Write("> ");
                DateTime dob = Convert.ToDateTime(Console.ReadLine());
                if (Validator.IsValidDateOfBirth(dob))
                {
                    customer.DateOfBirth = dob;
                }
                else
                {
                    Console.WriteLine("Invalid Date of Birth");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
