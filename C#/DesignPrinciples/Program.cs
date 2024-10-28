using DesignPrinciples.LSP;
using DesignPrinciples.OCP;
using DesignPrinciples.SRP;
namespace DesignPrinciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SRPDemo srpd = new();
            //srpd.SRPDemoMethod();
            //OCPDemo ocpd = new();
            //ocpd.OCPDemoMethod();
            LSPDemo lspd = new();
            lspd.LSPDemoMethod();
        }
    }
}
