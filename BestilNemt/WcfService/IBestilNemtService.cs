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
        //    int AddAdmin(Admin admin);

        [OperationContract]
        Admin GetAdmin(int id);
        
        //    [OperationContract]
        //    int DeleteAdmin(int id);

        //    [OperationContract]
        //    int UpdateAdmin(Admin admin);

        [OperationContract]
        int AddShop(Shop shop);

        [OperationContract]
        Shop GetShop(int id);
        
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
        
        [OperationContract]
        Login Login(Login login);
        
        //    [OperationContract]
        //    int UpdateLogin(Login login);
        
        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        Product GetProduct(int id);
        
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
        
        [OperationContract]
        List<Cart> GetAllCarts();

        [OperationContract]
        List<Cart> GetAllCartsByPersonId(int personId);
        
        [OperationContract]
        int AddPartOrder(PartOrder partOrder);
        
        // Warehouse
        [OperationContract]
        int AddWarehouse(Warehouse warehouse);

        [OperationContract]
        Warehouse GetWarehouse(int id);
        
        [OperationContract]
        List<Warehouse> GetAllWarehousesByShopId(int shopId);

        [OperationContract]
        int UpdateWarehouse(Warehouse warehouse);

        [OperationContract]
        int DeleteWarehouse(int id);

        [OperationContract]
        int AddSaving(Saving saving, Warehouse warehouse);

        [OperationContract]
        Saving GetSaving(int id);
        
        [OperationContract]
        int DeleteSaving(int id);
        
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

