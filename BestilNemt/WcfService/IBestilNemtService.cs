using Models;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace WcfService
{
    /// <summary>
    /// Interface for service
    /// </summary>
    [ServiceContract]
    public interface IBestilNemtService
    {
        //    [OperationContract]
        //    Customer GetCustomer(int id);

        //    [OperationContract]
        //    int AddCustomer(Customer customer);

        //    [OperationContract]
        //    int UpdateCustomer(Customer customer);

        //    [OperationContract]
        //    int DeleteCustomer(int id);

        //    [OperationContract]
        //    List<Customer> GetAllCustomer();

        //    [OperationContract]
        //    int AddAdmin(Admin admin);

        [OperationContract]
        Admin GetAdmin(int id);

        //    [OperationContract]
        //    List<Admin> GetAllAdmins();

        //    [OperationContract]
        //    int DeleteAdmin(int id);

        //    [OperationContract]
        //    int UpdateAdmin(Admin admin);

        [OperationContract]
        int AddShop(Shop shop);

        [OperationContract]
        Shop GetShop(int id);

        //    [OperationContract]
        //    List<Shop> GetAllShops();

        [OperationContract]
        List<Shop> GetAllShopsByChainId(int chainId);

        [OperationContract]
        int UpdateShop(Shop shop);

        [OperationContract]
        int DeleteShop(int id);

        [OperationContract]
        Chain GetChain(int id);

        [OperationContract]
        List<Chain> GetAllChains();

        //    [OperationContract]
        //    int DeleteChain(int id);

        //    [OperationContract]
        //    int AddChain(Chain chain);

        //    [OperationContract]
        //    int UpdateChain(Chain chain);

        [OperationContract]
        Login Login(Login login);

        //    [OperationContract]
        //    int AddLogin(Login login);

        //    [OperationContract]
        //    int UpdateLogin(Login login);

        //    [OperationContract]
        //    int DeleteLogin(Login login);

        //    [OperationContract]
        //    int AddCompany(Company company);

        //    [OperationContract]
        //    List<Company> GetAllCompany();

        //    [OperationContract]
        //    int DeleteCompany(int id);

        //    [OperationContract]
        //    int UpdateCompany(Company company);

        //    [OperationContract]
        //    Company GetCompany(int id);

        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        Product GetProduct(int id);

        //    [OperationContract]
        //    List<Product> GetAllProducts();

        [OperationContract]
        List<Product> GetAllSoldProducts();

        [OperationContract]
        List<Product> GetAllProductsWithSavings();

        [OperationContract]
        int UpdateProduct(Product product);

        [OperationContract]
        int DeleteProduct(int id);

        [OperationContract]
        int AddCart(Cart cart);

        [OperationContract]
        int AddCartWithPartOrders(Cart cart);

        //    [OperationContract]
        //    Cart GetCart(int id);

        //    [OperationContract]
        //    Cart GetCartWithPartOrders(int cartId);

        [OperationContract]
        List<Cart> GetAllCarts();

        [OperationContract]
        List<Cart> GetAllCartsByPersonId(int personId);

        //    [OperationContract]
        //    int UpdateCart(Cart cart);

        //    [OperationContract]
        //    int DeleteCart(int id);

        //    [OperationContract]
        //    int AddPartOrderToCart(Cart cart, PartOrder partOrder);

        //    [OperationContract]
        //    PartOrder GetPartOrder(int id);

        //    [OperationContract]
        //    int DeletePartOrder(int id);

        [OperationContract]
        int AddPartOrder(PartOrder partOrder);

        //    [OperationContract]
        //    int UpdatePartOrder(PartOrder partOrder);

        //    [OperationContract]
        //    List<PartOrder> GetAllPartOrders();

        // Warehouse
        [OperationContract]
        int AddWarehouse(Warehouse warehouse);

        [OperationContract]
        Warehouse GetWarehouse(int id);

        //    [OperationContract]
        //    List<Warehouse> GetAllWarehouses();

        [OperationContract]
        List<Warehouse> GetAllWarehousesByShopId(int shopId);

        [OperationContract]
        int UpdateWarehouse(Warehouse warehouse);

        //    [OperationContract]
        //    int DeleteWarehouse(int id);

        [OperationContract]
        int AddSaving(Saving saving, Warehouse warehouse);

        [OperationContract]
        Saving GetSaving(int id);

        //    [OperationContract]
        //    List<Saving> GetAllSavings();

        //    [OperationContract]
        //    int UpdateSaving(Saving saving);

        //    [OperationContract]
        //    int DeleteSaving(int id);

        //    [OperationContract]
        //    List<Product> GetAllProductsByName(string input);

        [OperationContract]
        int AddCustomerWithLogin(Customer customer, Login login);

        [OperationContract]
        Warehouse GetWarehouseByProductId(int productId, int shopId);

        [OperationContract]
        DataTable GetDataGridProducts();

        [OperationContract]
        DataTable GetProductWareHouse(int adminId);

        [OperationContract]
        DataTable GetChainData();

        [OperationContract]
        DataTable GetDataGridShop();
    }
}

