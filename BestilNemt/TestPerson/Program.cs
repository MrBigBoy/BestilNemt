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
            ServiceReference1.BestilNemtServiceClient proxy = new
               ServiceReference1.BestilNemtServiceClient();

            var find = proxy.findPerson(1);
            var findAll = proxy.GetALlPerson();
            
            Console.WriteLine(find.Name.ToString());
            Console.WriteLine(find)
           
        }
    }
}
