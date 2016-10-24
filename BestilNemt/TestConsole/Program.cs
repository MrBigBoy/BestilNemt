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
        static BestilNemtServiceRef.BestilNemtServiceClient proxy = new BestilNemtServiceRef.BestilNemtServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Username");
            //string Username = Console.ReadLine();
            string Username = "test@mail.dk";
            Console.WriteLine("Enter a Password");
            //string Password = Console.ReadLine();
            string Password = "testKode";
            
            Login login = proxy.Login(Username, Password);
            
            if(login.Id == 0)
            {
                Console.WriteLine("Login failed!");
            } else
            {
                Console.WriteLine("Login Successful!");
                Console.WriteLine("Id: {0}, Username: {1}, Password: {2}, personId: {3}", login.Id, login.Username, login.Password, login.PersonId);
            }
            
            Console.ReadLine();
            
        }
        
    }
}
