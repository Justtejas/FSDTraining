using CreationalPatterns.ChainOfRes;
using CreationalPatterns.DecoratorPattern;
using CreationalPatterns.FacadePattern;
using CreationalPatterns.FactoryPattern;
using CreationalPatterns.MediatorPattern;
using CreationalPatterns.ObserverPattern;
using CreationalPatterns.Singleton;
using CreationalPatterns.StructuralAdapterPattern;

namespace CreationalPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FactoryPatternDemo fpd = new();
            //fpd.FactoryPatternDemoMethod();
            //Configuration config1 = new Configuration();
            //Console.WriteLine(config1.Setting);
            //Configuration config2 = new Configuration();
            //Console.WriteLine(config2.Setting);
            //SAPDemo sapd = new();
            //sapd.SAPDemoMethod();
            //Facade facade = new();
            //facade.FacadeDemo();
            //DecPattern decp = new();
            //decp.DecPatternDemo();
            //    ChainOfResp cor = new();
            //    cor.ChainOfRespDemo();
            //MediatorDemo md = new();
            //md.MediatorDemoMethod();
            Observer ob = new();
            ob.ObserverDemo();
        }
    }
}
