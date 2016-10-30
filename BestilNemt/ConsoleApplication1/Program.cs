using System;
using System.ServiceModel;
using WcfService;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            using (var host = new ServiceHost(typeof(BestilNemtService)))
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
