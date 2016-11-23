using System;

namespace TestPerson
{
    internal class Program
    {
        private static readonly BestilNemtServiceRef.BestilNemtServiceClient Proxy = new BestilNemtServiceRef.BestilNemtServiceClient();

        private static void Main()
        {
            var find = Proxy.findPerson(1);
            Proxy.GetALlPerson();

            Console.WriteLine(find.Name);
            Console.ReadLine();
        }
    }
}
