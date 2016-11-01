using System;

namespace TestConsole
{
    internal class Program
    {
        private static readonly BestilNemtServiceRef.BestilNemtServiceClient Proxy = new BestilNemtServiceRef.BestilNemtServiceClient();

        private static void Main()
        {
            Console.WriteLine("Enter a Username");
            var username = Console.ReadLine();
            //string Username = "Admin";
            Console.WriteLine("Enter a Password");
            var password = Console.ReadLine();
            //string Password = "SuperAdmin";

            var login = Proxy.Login(username, password);

            if (login.Id == 0)
            {
                Console.WriteLine("Login failed!");
            }
            else
            {
                Console.WriteLine("Login Successful!");
                Console.WriteLine("Username: {0}, personId: {1}", login.Username, login.PersonId);
            }

            Console.ReadLine();

        }

    }
}
