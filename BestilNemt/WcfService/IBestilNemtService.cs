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
        Person findPerson(int id);

        [OperationContract]
        void createPerson(Person person);

        [OperationContract]
        List<Person> GetALlPerson();

        [OperationContract]
        Warehouse GetWarehouse(int id);

        [OperationContract]
        List<Warehouse> GetAllWarehouses();

        [OperationContract]
        void RemoveWarehouse(int id);

        [OperationContract]
        void AddWarehouse(Warehouse warehouse);

        [OperationContract]
        void UpdateWarehouse(Warehouse warehouse);

        
        [OperationContract]
        Shop GetShop(int id);

        [OperationContract]
        List<Shop> GetAllShops();

        [OperationContract]
        int DeleteShop(int id);

        [OperationContract]
        int AddShop(Shop shop);

        [OperationContract]
        int UpdateShop(Shop shop);

        [OperationContract]
        Login Login(Login login);

        [OperationContract]
        int AddLogin(Login login);

        [OperationContract]
        int UpdateLogin(Login login);

        [OperationContract]
        int DelLogin(Login login);
    }


}

