using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BestilNemtService)))
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
