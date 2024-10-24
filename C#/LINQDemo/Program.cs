using System.Security.Cryptography;

namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Tejas","Akash","Prathmesh","Aniket"};

            // query synatx
            var nameContainsE = from name in names
                                where (name.Contains('e'))
                                select name;
            Console.WriteLine("------------------- Names with E in them using query syntax -------------------");
            foreach(var name in nameContainsE)
            {
                Console.WriteLine(name);
            }

            List<string> nameContainsS = names.Where(name => name.Contains('s')).ToList();
            Console.WriteLine("------------------- Names with S in them using LINQ syntax -------------------");
            foreach (string name in nameContainsS)
            {
                Console.WriteLine(name);
            }

            List<Student> students = new()
            {
                new() {StudentID = 1, Name= "Tejas", Age = 17},
                new() {StudentID = 2, Name= "Akash", Age = 20},
                new() {StudentID = 3, Name= "Amol", Age = 16},
                new() {StudentID = 4, Name= "Aniket", Age = 19},
                new() {StudentID = 5, Name= "Prathmesh", Age = 21},
            };
            Student.GetTeenageStudents(students);
           
        }
    }
}
