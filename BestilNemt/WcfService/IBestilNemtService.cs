using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBestilNemtService
    {
        [OperationContract]
        string GetData(int value);

        
        [OperationContract]
        Shop GetShop(int id);

        [OperationContract]
        List<Shop> GetAllShops();

        [OperationContract]
        void DeleteShop(int id);

        [OperationContract]
        void AddShop(Shop shop);

        [OperationContract]
        void UpdateShop(Shop shop);


    }


}

