using Models;
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
            List<Shop> shops = proxy.GetAllShops();
            Console.WriteLine(shops.Count);
            Console.ReadLine();
        }
    }
}
