using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPerson
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceReference2.BestilNemtServiceClient proxy = new
               ServiceReference2.BestilNemtServiceClient();

            var find = proxy.findPerson(1);
            //var findAll = proxy.GetALlPerson();
            
            Console.WriteLine(find.Name.ToString());
            // Console.WriteLine(find);
            Console.ReadLine();
           
        }
    }
}
