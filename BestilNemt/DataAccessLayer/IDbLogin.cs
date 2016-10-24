using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDbLogin
    {
        Models.Login Login(string username, string password);
    }
}
