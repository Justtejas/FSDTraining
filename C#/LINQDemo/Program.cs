namespace LINQDemo
{
    internal class Program
    {
        static void Main()
        {
            //string[] names = {"Tejas","Akash","Prathmesh","Aniket"};

            //// query synatx
            //var nameContainsE = from name in names
            //                    where (name.Contains('e'))
            //                    select name;
            //Console.WriteLine("------------------- Names with E in them using query syntax -------------------");
            //foreach(var name in nameContainsE)
            //{
            //    Console.WriteLine(name);
            //}

            //List<string> nameContainsS = names.Where(name => name.Contains('s')).ToList();
            //Console.WriteLine("------------------- Names with S in them using LINQ syntax -------------------");
            //foreach (string name in nameContainsS)
            //{
            //    Console.WriteLine(name);
            //}

            //List<Student> students = new()
            //{
            //new() { StudentID = 1, Name = "Tejas", Age = 17 },
            //    new() { StudentID = 2, Name = "Akash", Age = 20 },
            //    new() { StudentID = 3, Name = "Amol", Age = 16 },
            //    new() { StudentID = 4, Name = "Aniket", Age = 19 },
            //    new() { StudentID = 5, Name = "Prathmesh", Age = 21 },
            //};
            //Student.GetTeenageStudents(students);

            //OfTypeOperator oto = new();
            //oto.DisplayList();
            //OrderByDemo();
            //GroupByDemo();
            //JoinsDemo();
            FirstDemo();

        }
        public static void OrderByDemo()
        {
            IList<Student> students = new List<Student>()
            {
                new() { StudentID = 1, Name = "Tejas", Age = 17 },
                new() { StudentID = 2, Name = "Akash", Age = 20 },
                new() { StudentID = 3, Name = "Amol", Age = 20 },
                new() { StudentID = 4, Name = "Aniket", Age = 19 },
                new() { StudentID = 5, Name = "Prathm", Age = 21 },
            };

            Console.WriteLine("\n --------------- Query syntax --------------");
            List<Student> orderByAsc = (from student in students
                                        orderby student.Name
                                        select student).ToList();
            List<Student> orderByDesc = (from student in students
                                         orderby student.Name descending
                                         select student).ToList();
            Console.WriteLine("\n ----------- Ascending by name ------------ \n");
            foreach (Student student in orderByAsc)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\n ----------- Descending by name ------------ \n");
            foreach (Student student in orderByDesc)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n --------------- Method syntax --------------");
            List<Student> orderByAscLINQ = students.OrderBy(student => student.Name).ToList();
            Console.WriteLine("\n ----------- Ascending by name ------------ \n");
            foreach (Student student in orderByAscLINQ)
            {
                Console.WriteLine(student);
            }
            List<Student> orderByDescLINQ = students.OrderByDescending(student => student.Name).ToList();
            Console.WriteLine("\n ----------- Descending by name ------------ \n");
            foreach (Student student in orderByDescLINQ)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n --------------- Query syntax --------------");
            List<Student> orderByAscMultiCol = (from student in students
                                                orderby student.Age, student.Name descending
                                                select student).ToList();
            Console.WriteLine("\n ----------- Ascending by Age, Descending by Name Query Syntax ------------ \n");
            foreach (Student student in orderByAscMultiCol)
            {
                Console.WriteLine(student);
            }
            List<Student> orderByAscMultiColLINQ = students.OrderBy(student => student.Age).ThenByDescending(student => student.Name).ToList();
            Console.WriteLine("\n ----------- Ascending by Age, Descending By Name Method Syntax ------------ \n");
            foreach (Student student in orderByAscMultiColLINQ)
            {
                Console.WriteLine(student);
            }
        }
        public static void GroupByDemo()
        {
            IList<Student> students = new List<Student>()
            {
                new() { StudentID = 1, Name = "Tejas", Age = 17 },
                new() { StudentID = 2, Name = "Akash", Age = 20 },
                new() { StudentID = 3, Name = "Amol", Age = 20 },
                new() { StudentID = 4, Name = "Aniket", Age = 21 },
                new() { StudentID = 5, Name = "Prathm", Age = 21 },
            };

            Console.WriteLine("\n ----------------- Query Syntax --------------- \n");
            List<IGrouping<int,Student>> groupByAge = (from student in students
                                       group student by student.Age).ToList();
            Console.WriteLine("\n ---------- Grouping by age ----------------");
            foreach( IGrouping<int,Student>student in groupByAge)
            {
                foreach(Student stud in student)
                {
                    Console.WriteLine(stud);
                }
            }

            Console.WriteLine("\n ------------- Method syntax -------------- \n");
            List<IGrouping<int,Student>> groupByAgeLINQ = students.GroupBy(student => student.Age).ToList(); // deferred execution
            Console.WriteLine("\n ---------- Grouping by age ----------------");
            foreach( IGrouping<int,Student>student in groupByAgeLINQ)
            {
                foreach(Student stud in student)
                {
                    Console.WriteLine(stud);
                }
            }
        }
        public static void JoinsDemo()
        {
            IList<Student> students = new List<Student>()
            {
                new() { StudentID = 1, Name = "Tejas", Age = 17, CourseID = 1 },
                new() { StudentID = 2, Name = "Akash", Age = 20, CourseID = 2 },
                new() { StudentID = 3, Name = "Amol", Age = 20, CourseID = 2 },
                new() { StudentID = 4, Name = "Aniket", Age = 21, CourseID = 2 },
                new() { StudentID = 5, Name = "Prathm", Age = 21, CourseID = 1 },
            };

            IList<Course> courses = new List<Course>()
            {
                new() {  CourseID = 1, CourseName = "Java" },
                new() {  CourseID = 2, CourseName = "Python" },
            };

            var joinedList = students.Join(
               courses,
               student => student.CourseID,
               course => course.CourseID,
               (student, course) => new
               {
                    studentName = student.Name,
                    studentAge = student.Age,
                    studentCourse = course.CourseName
               }).ToList();

            Console.WriteLine("\n ---------- From Students And Courses List ---------------");
            foreach(var student in joinedList)
            {
                Console.WriteLine(student);
            }
        }
        public static void FirstDemo()
        {
            IList<Student> students = new List<Student>()
            {
                new() { StudentID = 1, Name = "Tejas", Age = 17, CourseID = 1 },
                new() { StudentID = 2, Name = "Akash", Age = 20, CourseID = 2 },
                new() { StudentID = 3, Name = "Amol", Age = 20, CourseID = 2 },
                new() { StudentID = 4, Name = "Aniket", Age = 21, CourseID = 2 },
                new() { StudentID = 5, Name = "Prathm", Age = 21, CourseID = 1 },
            };

            Student firstResult = students.First();
            Student lastRes = students.Last();
            Console.WriteLine($"First Element from the students is {firstResult.Name} {firstResult.StudentID}");
            Console.WriteLine($"Last Element from the students is {lastRes.Name} {lastRes.StudentID}");
            List<int> numbers = new List<int>() { 45,49,101,143};
            var evenList = numbers.Where(num => (num & 1) == 0);
            // can't get first from empty list
            //Console.WriteLine($"First even from even list is {evenList.First()}");
            // FirstOrDefault
            Console.WriteLine($"First even from even list is {evenList.FirstOrDefault()}");
            // last
            // can't get first from empty list
            //Console.WriteLine($"First even from even list is {evenList.Last()}");
            // LastOrDefault
            Console.WriteLine($"First even from even list is {evenList.LastOrDefault()}");
        }
    }
}
