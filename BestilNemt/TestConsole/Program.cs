using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService;

namespace TestConsole
{
    class Program
    {
        static IBestilNemtService proxy = new BestilNemtService();

        static void Main(string[] args)
        {
            string str = proxy.GetData(4);
            Console.WriteLine("{0}", str);
            Console.ReadLine();
        }
    }
}
