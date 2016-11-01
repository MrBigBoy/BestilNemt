using System;
using System.ServiceModel;
using WcfService;

namespace HostApplication
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
