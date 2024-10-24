using System.Collections;

namespace LINQDemo
{
    internal class OfTypeOperator
    {
        public void DisplayList()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(1);
            mixedList.Add(3);
            mixedList.Add("Tejas");
            mixedList.Add("Hexaware");
            mixedList.Add(new Student() { StudentID= 1, Name = "Akash", Age = 23});
            mixedList.Add(new Student() { StudentID= 2, Name = "Amol", Age = 22});

            var stringResult = (from stringType in mixedList.OfType<string>() select stringType).ToList();
            var intResult = (from intType in mixedList.OfType<int>() select intType).ToList();
            var studentResult = (from studentType in mixedList.OfType<Student>() select studentType).ToList();
            Console.WriteLine(" --------------- Using Query Syntax ---------------");

            Console.WriteLine("\n--- string type ---\n");
            foreach(string stringR in stringResult)
            {
                Console.WriteLine(stringR);
            }
            Console.WriteLine("\n--- int type ---\n");
            foreach(int intR in intResult)
            {
                Console.WriteLine(intR);
            }
            Console.WriteLine("\n--- student type ---\n");
            foreach(Student studType in studentResult)
            {
                Console.WriteLine(studType);
            }

            var stringResultLINQ = mixedList.OfType<string>().ToList();
            var intResultLINQ = mixedList.OfType<int>().ToList();
            var studentResultLINQ =mixedList.OfType<Student>().ToList();

            Console.WriteLine("\n --------------- Using Method Syntax ---------------");

            Console.WriteLine("\n--- string type ---\n");
            foreach(string stringR in stringResultLINQ)
            {
                Console.WriteLine(stringR);
            }
            Console.WriteLine("\n--- int type ---\n");
            foreach(int intR in intResultLINQ)
            {
                Console.WriteLine(intR);
            }
            Console.WriteLine("\n--- student type ---\n");
            foreach(Student studType in studentResultLINQ)
            {
                Console.WriteLine(studType);
            }
        }
    }
}
