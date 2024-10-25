using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace FileIODemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WriteToFile();
            //DirDemo();
            //StreamWriterAndReaderDemo();
            //JSONSerializeAndDeserializeDemo();
            //XMLSerializeAndDeserializeDemo();
            RegexMatching();
        }
        public static void WriteToFile()
        {
            string path = @"C:\Users\dell\Desktop\FSD\C#\FileIODemo\sample.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                AddTextInTheFile(fs, "Hello From C# Program");
                AddTextInTheFile(fs, "\nHello From C# Program");
                AddTextInTheFile(fs, "\rHello From C# Program");
            }
        }
        public static void AddTextInTheFile(FileStream fs, string content)
        {
            byte[] buffer = new UTF32Encoding().GetBytes(content);
            fs.Write(buffer,0,buffer.Length);
        }
        public static void DirDemo()
        {
            string sourceDir = @"C:\Users\dell\Desktop\Hexaware\Coding Challenge";
            string destDir = @"C:\Users\dell\Desktop\Hexaware\Coding Challenge 2";

            Directory.CreateDirectory(destDir);
            DirectoryInfo sourceDInfo = new(sourceDir);
            DirectoryInfo destDirInfo = new(destDir);

            foreach (FileInfo fi in sourceDInfo.GetFiles())
            {
                fi.CopyTo(Path.Combine(destDirInfo.FullName,fi.Name),false);
                Console.WriteLine("Copying files from SRC to DEST");
            }
            foreach (DirectoryInfo di in sourceDInfo.GetDirectories())
            {
                DirectoryInfo destSubDir = destDirInfo.CreateSubdirectory(di.Name);
                foreach (FileInfo fi in di.GetFiles())
                {
                    fi.CopyTo(Path.Combine(destSubDir.FullName, fi.Name), false);
                    Console.WriteLine("Copying files from SubSRC to SubDEST");
                }
            }


        }

        public static void StreamWriterAndReaderDemo()
        {
            string filePath = @"C:\Users\dell\Desktop\Hexaware\writer.txt";
            using (StreamWriter sw = new(filePath))
            {
                sw.WriteLine("Hello from Stream Writer");
            }
            using StreamReader sr = new(filePath);
            string contentFromFile = sr.ReadToEnd();
            Console.WriteLine(contentFromFile);

        }

        public static void JSONSerializeAndDeserializeDemo()
        {
            Products products = new() { ID = 1, Name = "Toy", Description = "A Plastic Toy", Price = 30};
            string jsonString = JsonSerializer.Serialize(products);
            Console.WriteLine($"Serialized Data {jsonString}");
            string filePath = @"C:\Users\dell\Desktop\Hexaware\writer.json";
            File.WriteAllText(filePath,jsonString);

            string readResult = File.ReadAllText(filePath);
            Products prod = JsonSerializer.Deserialize<Products>(readResult);
            Console.WriteLine("\nDeserialized Data: " + prod);
        }
        public static void XMLSerializeAndDeserializeDemo()
        {
            Products products = new() { ID = 1, Name = "Toy", Description = "A Plastic Toy", Price = 30};
            string filePath = @"C:\Users\dell\Desktop\Hexaware\writer.dat";
            XmlSerializer xmlSerializer = new(typeof(Products));
            using(FileStream fs = new(filePath,FileMode.Create))
            {
                xmlSerializer.Serialize(fs, products);
            }
            Console.WriteLine("File Serialized to XML");

            using (FileStream fs = new(filePath,FileMode.Open))
            {
                Products prod = (Products)xmlSerializer.Deserialize(fs);
                Console.WriteLine("\nDeserialized Data: " + prod);
            }
        }
        public static void RegexMatching()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in)$";
            string[] emails = {"tejas@gmail.com","gmail.com@tejas","alkfjasdlkfjlksdafjlksk@sdkflksdjflksdjf.com","hexaw+are@hexaware.com"};
            foreach (string email in emails)
            {
                if(Regex.IsMatch(email, emailPattern))
                {
                    Console.WriteLine($"Valid Email: {email}");
                }
                else
                {
                    Console.WriteLine($"Invalid Email: {email}");
                }
            }

            Console.WriteLine("Enter the text to extract numbers from:");
            string input = Console.ReadLine();
            string numberPattern = @"\d+";
            foreach(Match match in Regex.Matches(input, numberPattern))
            {
                Console.WriteLine($"Found Number: {match.Value}");
            }
            string input2 = "Kejas Pankoji";
            string res = Regex.Replace(input2, "k", match => match.Value == "K" ? "T" : "t",
                RegexOptions.IgnoreCase);
            Console.WriteLine(res);
            
            string sentence = "It is easy to follow and easy to practice";
            string wordToHighlight = "easy";

            string ress = Regex.Replace(sentence,wordToHighlight,match => $"[{match.Value}]",RegexOptions.IgnoreCase);
            Console.WriteLine(ress);


        }
    }
}
