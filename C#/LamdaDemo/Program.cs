namespace LambdaDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Numbers.Demo();

            List<Employee> employees = new()
            {
                new() {EmployeeId = 1, Name = "Tejas", Experience = 1, Salary = 20000.0 },
                new() {EmployeeId = 2, Name = "Ajay", Experience = 2, Salary = 30000.0 },
                new() {EmployeeId = 3, Name = "Varun", Experience = 5, Salary = 50000.0 },
                new() {EmployeeId = 4, Name = "Sanket", Experience = 6, Salary = 70000.0 },
            };
            Console.WriteLine("\n------------- Employees List --------------");
            foreach (Employee emp in employees) {
                Console.WriteLine(emp.ToString()); 
            }

            var employeeIdsByDesc = employees.OrderByDescending(emp => emp.EmployeeId);
            Console.WriteLine("\n------------- Employees List by Descending order --------------");
            foreach (var emp in employeeIdsByDesc) {
                Console.WriteLine(emp); 
            }
        }
    }
}
