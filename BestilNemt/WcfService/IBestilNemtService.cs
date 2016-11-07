using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IBestilNemtService
    {
        [OperationContract]
        Customer FindCustomer(int id);

        [OperationContract]
        int CreateCustomer(Customer customer);
        [OperationContract]
        int UpdateCustomer(Customer customer);
        [OperationContract]
        int RemoveCustomer(int id);

        [OperationContract]
        List<Customer> GetALlCustomer();

        [OperationContract]
        void CreateAdmin(Admin admin);

        [OperationContract]
        Admin FindAdmin(int id);

        [OperationContract]
        List<Admin> GetAllAdmins();

        [OperationContract]
        int RemoveAdmin(int id);

        [OperationContract]
        void UpdateAdmin(Admin admin);
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

        [OperationContract]
        void CreateCompany(Company company);

        [OperationContract]
        List<Company> FindAllCompany();
        [OperationContract]
        int RemoveCompany(int id);
        [OperationContract]
        void UpdateCompany(Company company);
        [OperationContract]
        Company FindCompany(int id);
    }


}

