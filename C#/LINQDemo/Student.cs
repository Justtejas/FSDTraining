namespace LINQDemo
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CourseID { get; set; }

        public override string ToString()
        {
            return $"StudentID: {StudentID}\t Name: {Name}\t Age: {Age}";
        }
        public static void GetTeenageStudents(List<Student> students)
        {
            // query syntax
            List<Student> teenageStudents = (from student in students
                                             where (student.Age >= 13 && student.Age <= 19)
                                             select student
                                            ).ToList();

            Console.WriteLine("------------------- using query syntax -------------------");
            foreach (Student student in teenageStudents)
            {
                Console.WriteLine(student.ToString());
            }

            // linq syntax
            List<Student> teenageStudentsWithLINQ = students.Where(s => (s.Age >= 13 && s.Age <= 19)).ToList();
            Console.WriteLine("------------------- using LINQ syntax -------------------");
            foreach(Student student in teenageStudentsWithLINQ)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
