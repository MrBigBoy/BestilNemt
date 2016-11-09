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
        int AddCustomer(Customer customer);
        [OperationContract]
        int UpdateCustomer(Customer customer);
        [OperationContract]
        int DeleteCustomer(int id);

        [OperationContract]
        List<Customer> GetAllCustomer();

        [OperationContract]
        int AddAdmin(Admin admin);

        [OperationContract]
        Admin FindAdmin(int id);

        [OperationContract]
        List<Admin> GetAllAdmins();

        [OperationContract]
        int DeleteAdmin(int id);

        [OperationContract]
        int UpdateAdmin(Admin admin);
        [OperationContract]
        Warehouse GetWarehouse(int id);

        [OperationContract]
        List<Warehouse> GetAllWarehouses();

        [OperationContract]
        int RemoveWarehouse(int id);

        [OperationContract]
        int AddWarehouse(Warehouse warehouse);

        [OperationContract]
        int UpdateWarehouse(Warehouse warehouse);
        
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
        int DeleteLogin(Login login);

        [OperationContract]
        int AddCompany(Company company);

        [OperationContract]
        List<Company> FindAllCompany();
        [OperationContract]
        int DeleteCompany(int id);
        [OperationContract]
        int UpdateCompany(Company company);
        [OperationContract]
        Company FindCompany(int id);

        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        int UpdateProduct(Product product);
        [OperationContract]
        int DeleteProduct(int id);

        [OperationContract]
        int AddCart(Cart cart);
        [OperationContract]
        Cart FindCart(int id);
        [OperationContract]
        List<Cart> GetAllCarts();
        [OperationContract]
        int UpdateCart(Cart cart);
        [OperationContract]
        int DeleteCart(int id);

       

    }


}

