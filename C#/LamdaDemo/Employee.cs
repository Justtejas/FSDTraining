namespace LambdaDemo
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"\nEmployeeID: {EmployeeId} \t Name: {Name} \t Experience: {Experience} \t Salary: {Salary}";
        }
    }
}
