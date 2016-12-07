using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Client.BestilNemtWPF;

namespace WPF_Client
{
   public class LoginManager
    {
        private static BestilNemtServiceClient Proxy;
        public static Login User { get; set; }
        public static void Setup(BestilNemtServiceClient proxy)
        {
            Proxy = proxy;
        }
        public static Login Login(string username, string password)
        {
            Login login = new Login();
            login.Username = username;
            login.Password = password;
            User = Proxy.Login(login);
            return User;
    }
    }
}
