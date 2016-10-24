using Models;
using System;

namespace TestConsole
{
    class Program
    {
        private static readonly BestilNemtServiceRef.BestilNemtServiceClient Proxy = new BestilNemtServiceRef.BestilNemtServiceClient();

        private static void Main()
        {
            Console.WriteLine("Enter a Username");
            var username = Console.ReadLine();
            //string Username = "test@mail.dk";
            Console.WriteLine("Enter a Password");
            var password = Console.ReadLine();
            //string Password = "testKode";

            Login login = Proxy.Login(username, password);

            if (login.Id == 0)
            {
                Console.WriteLine("Login failed!");
            }
            else
            {
                Console.WriteLine("Login Successful!");
                Console.WriteLine("Id: {0}, Username: {1}, Password: {2}, personId: {3}", login.Id, login.Username, login.Password, login.PersonId);
            }

            Console.ReadLine();

        }

    }
}
