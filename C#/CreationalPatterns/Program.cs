using CreationalPatterns.FactoryPattern;
using CreationalPatterns.Singleton;

namespace CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FactoryPatternDemo fpd = new();
            //fpd.FactoryPatternDemoMethod();
            Configuration config1 = new Configuration();
            Console.WriteLine(config1.Setting);
            Configuration config2 = new Configuration();
            Console.WriteLine(config2.Setting);
        }
    }
}
