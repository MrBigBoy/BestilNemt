using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    
    [ServiceContract]
    public interface IBestilNemtService
    {
        [OperationContract]
        SqlConnection GetConnection();
        [OperationContract]
        string GetData(int value);
        [OperationContract]
        Login Login(string Username, string Password);
    }
}
