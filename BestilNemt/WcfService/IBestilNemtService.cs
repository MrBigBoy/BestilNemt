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
        void DeleteShop(int id);

        [OperationContract]
        void AddShop(Shop shop);

        [OperationContract]
        void UpdateShop(Shop shop);

        [OperationContract]
        Login Login(string username, string password);

        [OperationContract]
        int AddLogin(string username, string password, int personId);
    }


}

