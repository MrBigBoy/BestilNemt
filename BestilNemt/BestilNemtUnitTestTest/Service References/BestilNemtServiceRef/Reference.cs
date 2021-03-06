﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BestilNemtUnitTestTest.BestilNemtServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BestilNemtServiceRef.IBestilNemtService")]
    public interface IBestilNemtService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/GetAdminResponse")]
        Models.Admin GetAdmin(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/GetAdminResponse")]
        System.Threading.Tasks.Task<Models.Admin> GetAdminAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        int AddShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        System.Threading.Tasks.Task<int> AddShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetShopResponse")]
        Models.Shop GetShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetShopResponse")]
        System.Threading.Tasks.Task<Models.Shop> GetShopAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllShopsByChainId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllShopsByChainIdResponse")]
        Models.Shop[] GetAllShopsByChainId(int chainId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllShopsByChainId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllShopsByChainIdResponse")]
        System.Threading.Tasks.Task<Models.Shop[]> GetAllShopsByChainIdAsync(int chainId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        int UpdateShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        System.Threading.Tasks.Task<int> UpdateShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteShop", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteShopResponse")]
        int DeleteShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteShop", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteShopResponse")]
        System.Threading.Tasks.Task<int> DeleteShopAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetChain", ReplyAction="http://tempuri.org/IBestilNemtService/GetChainResponse")]
        Models.Chain GetChain(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetChain", ReplyAction="http://tempuri.org/IBestilNemtService/GetChainResponse")]
        System.Threading.Tasks.Task<Models.Chain> GetChainAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllChains", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllChainsResponse")]
        Models.Chain[] GetAllChains();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllChains", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllChainsResponse")]
        System.Threading.Tasks.Task<Models.Chain[]> GetAllChainsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        Models.Login Login([System.ServiceModel.MessageParameterAttribute(Name="login")] Models.Login login1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        System.Threading.Tasks.Task<Models.Login> LoginAsync(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddProduct", ReplyAction="http://tempuri.org/IBestilNemtService/AddProductResponse")]
        int AddProduct(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddProduct", ReplyAction="http://tempuri.org/IBestilNemtService/AddProductResponse")]
        System.Threading.Tasks.Task<int> AddProductAsync(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProduct", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductResponse")]
        Models.Product GetProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProduct", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductResponse")]
        System.Threading.Tasks.Task<Models.Product> GetProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllSoldProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllSoldProductsResponse")]
        Models.Product[] GetAllSoldProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllSoldProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllSoldProductsResponse")]
        System.Threading.Tasks.Task<Models.Product[]> GetAllSoldProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllProductsWithSavings", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllProductsWithSavingsResponse")]
        Models.Product[] GetAllProductsWithSavings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllProductsWithSavings", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllProductsWithSavingsResponse")]
        System.Threading.Tasks.Task<Models.Product[]> GetAllProductsWithSavingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateProduct", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateProductResponse")]
        int UpdateProduct(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateProduct", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateProductResponse")]
        System.Threading.Tasks.Task<int> UpdateProductAsync(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteProduct", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteProductResponse")]
        int DeleteProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteProduct", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteProductResponse")]
        System.Threading.Tasks.Task<int> DeleteProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCart", ReplyAction="http://tempuri.org/IBestilNemtService/AddCartResponse")]
        int AddCart(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCart", ReplyAction="http://tempuri.org/IBestilNemtService/AddCartResponse")]
        System.Threading.Tasks.Task<int> AddCartAsync(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCartWithPartOrders", ReplyAction="http://tempuri.org/IBestilNemtService/AddCartWithPartOrdersResponse")]
        int AddCartWithPartOrders(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCartWithPartOrders", ReplyAction="http://tempuri.org/IBestilNemtService/AddCartWithPartOrdersResponse")]
        System.Threading.Tasks.Task<int> AddCartWithPartOrdersAsync(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCarts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsResponse")]
        Models.Cart[] GetAllCarts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCarts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsResponse")]
        System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCartsByPersonId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsByPersonIdResponse")]
        Models.Cart[] GetAllCartsByPersonId(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCartsByPersonId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsByPersonIdResponse")]
        System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsByPersonIdAsync(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/AddPartOrderResponse")]
        int AddPartOrder(Models.PartOrder partOrder);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/AddPartOrderResponse")]
        System.Threading.Tasks.Task<int> AddPartOrderAsync(Models.PartOrder partOrder);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        int AddWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        System.Threading.Tasks.Task<int> AddWarehouseAsync(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        Models.Warehouse GetWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehousesByShopId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesByShopIdResponse")]
        Models.Warehouse[] GetAllWarehousesByShopId(int shopId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehousesByShopId", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesByShopIdResponse")]
        System.Threading.Tasks.Task<Models.Warehouse[]> GetAllWarehousesByShopIdAsync(int shopId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        int UpdateWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        System.Threading.Tasks.Task<int> UpdateWarehouseAsync(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteWarehouseResponse")]
        int DeleteWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteWarehouseResponse")]
        System.Threading.Tasks.Task<int> DeleteWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddSaving", ReplyAction="http://tempuri.org/IBestilNemtService/AddSavingResponse")]
        int AddSaving(Models.Saving saving, Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddSaving", ReplyAction="http://tempuri.org/IBestilNemtService/AddSavingResponse")]
        System.Threading.Tasks.Task<int> AddSavingAsync(Models.Saving saving, Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetSaving", ReplyAction="http://tempuri.org/IBestilNemtService/GetSavingResponse")]
        Models.Saving GetSaving(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetSaving", ReplyAction="http://tempuri.org/IBestilNemtService/GetSavingResponse")]
        System.Threading.Tasks.Task<Models.Saving> GetSavingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteSaving", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteSavingResponse")]
        int DeleteSaving(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteSaving", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteSavingResponse")]
        System.Threading.Tasks.Task<int> DeleteSavingAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCustomerWithLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddCustomerWithLoginResponse")]
        int AddCustomerWithLogin(Models.Customer customer, Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCustomerWithLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddCustomerWithLoginResponse")]
        System.Threading.Tasks.Task<int> AddCustomerWithLoginAsync(Models.Customer customer, Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouseByProductId", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseByProductIdResponse")]
        Models.Warehouse GetWarehouseByProductId(int productId, int shopId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouseByProductId", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseByProductIdResponse")]
        System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseByProductIdAsync(int productId, int shopId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetDataGridProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataGridProductsResponse")]
        System.Data.DataTable GetDataGridProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetDataGridProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataGridProductsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetDataGridProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProductWareHouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductWareHouseResponse")]
        System.Data.DataTable GetProductWareHouse(int adminId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProductWareHouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductWareHouseResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetProductWareHouseAsync(int adminId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetChainData", ReplyAction="http://tempuri.org/IBestilNemtService/GetChainDataResponse")]
        System.Data.DataTable GetChainData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetChainData", ReplyAction="http://tempuri.org/IBestilNemtService/GetChainDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetChainDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetDataGridShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataGridShopResponse")]
        System.Data.DataTable GetDataGridShop();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetDataGridShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetDataGridShopResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetDataGridShopAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBestilNemtServiceChannel : BestilNemtUnitTestTest.BestilNemtServiceRef.IBestilNemtService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BestilNemtServiceClient : System.ServiceModel.ClientBase<BestilNemtUnitTestTest.BestilNemtServiceRef.IBestilNemtService>, BestilNemtUnitTestTest.BestilNemtServiceRef.IBestilNemtService {
        
        public BestilNemtServiceClient() {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BestilNemtServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BestilNemtServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Models.Admin GetAdmin(int id) {
            return base.Channel.GetAdmin(id);
        }
        
        public System.Threading.Tasks.Task<Models.Admin> GetAdminAsync(int id) {
            return base.Channel.GetAdminAsync(id);
        }
        
        public int AddShop(Models.Shop shop) {
            return base.Channel.AddShop(shop);
        }
        
        public System.Threading.Tasks.Task<int> AddShopAsync(Models.Shop shop) {
            return base.Channel.AddShopAsync(shop);
        }
        
        public Models.Shop GetShop(int id) {
            return base.Channel.GetShop(id);
        }
        
        public System.Threading.Tasks.Task<Models.Shop> GetShopAsync(int id) {
            return base.Channel.GetShopAsync(id);
        }
        
        public Models.Shop[] GetAllShopsByChainId(int chainId) {
            return base.Channel.GetAllShopsByChainId(chainId);
        }
        
        public System.Threading.Tasks.Task<Models.Shop[]> GetAllShopsByChainIdAsync(int chainId) {
            return base.Channel.GetAllShopsByChainIdAsync(chainId);
        }
        
        public int UpdateShop(Models.Shop shop) {
            return base.Channel.UpdateShop(shop);
        }
        
        public System.Threading.Tasks.Task<int> UpdateShopAsync(Models.Shop shop) {
            return base.Channel.UpdateShopAsync(shop);
        }
        
        public int DeleteShop(int id) {
            return base.Channel.DeleteShop(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteShopAsync(int id) {
            return base.Channel.DeleteShopAsync(id);
        }
        
        public Models.Chain GetChain(int id) {
            return base.Channel.GetChain(id);
        }
        
        public System.Threading.Tasks.Task<Models.Chain> GetChainAsync(int id) {
            return base.Channel.GetChainAsync(id);
        }
        
        public Models.Chain[] GetAllChains() {
            return base.Channel.GetAllChains();
        }
        
        public System.Threading.Tasks.Task<Models.Chain[]> GetAllChainsAsync() {
            return base.Channel.GetAllChainsAsync();
        }
        
        public Models.Login Login(Models.Login login1) {
            return base.Channel.Login(login1);
        }
        
        public System.Threading.Tasks.Task<Models.Login> LoginAsync(Models.Login login) {
            return base.Channel.LoginAsync(login);
        }
        
        public int AddProduct(Models.Product product) {
            return base.Channel.AddProduct(product);
        }
        
        public System.Threading.Tasks.Task<int> AddProductAsync(Models.Product product) {
            return base.Channel.AddProductAsync(product);
        }
        
        public Models.Product GetProduct(int id) {
            return base.Channel.GetProduct(id);
        }
        
        public System.Threading.Tasks.Task<Models.Product> GetProductAsync(int id) {
            return base.Channel.GetProductAsync(id);
        }
        
        public Models.Product[] GetAllSoldProducts() {
            return base.Channel.GetAllSoldProducts();
        }
        
        public System.Threading.Tasks.Task<Models.Product[]> GetAllSoldProductsAsync() {
            return base.Channel.GetAllSoldProductsAsync();
        }
        
        public Models.Product[] GetAllProductsWithSavings() {
            return base.Channel.GetAllProductsWithSavings();
        }
        
        public System.Threading.Tasks.Task<Models.Product[]> GetAllProductsWithSavingsAsync() {
            return base.Channel.GetAllProductsWithSavingsAsync();
        }
        
        public int UpdateProduct(Models.Product product) {
            return base.Channel.UpdateProduct(product);
        }
        
        public System.Threading.Tasks.Task<int> UpdateProductAsync(Models.Product product) {
            return base.Channel.UpdateProductAsync(product);
        }
        
        public int DeleteProduct(int id) {
            return base.Channel.DeleteProduct(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteProductAsync(int id) {
            return base.Channel.DeleteProductAsync(id);
        }
        
        public int AddCart(Models.Cart cart) {
            return base.Channel.AddCart(cart);
        }
        
        public System.Threading.Tasks.Task<int> AddCartAsync(Models.Cart cart) {
            return base.Channel.AddCartAsync(cart);
        }
        
        public int AddCartWithPartOrders(Models.Cart cart) {
            return base.Channel.AddCartWithPartOrders(cart);
        }
        
        public System.Threading.Tasks.Task<int> AddCartWithPartOrdersAsync(Models.Cart cart) {
            return base.Channel.AddCartWithPartOrdersAsync(cart);
        }
        
        public Models.Cart[] GetAllCarts() {
            return base.Channel.GetAllCarts();
        }
        
        public System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsAsync() {
            return base.Channel.GetAllCartsAsync();
        }
        
        public Models.Cart[] GetAllCartsByPersonId(int personId) {
            return base.Channel.GetAllCartsByPersonId(personId);
        }
        
        public System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsByPersonIdAsync(int personId) {
            return base.Channel.GetAllCartsByPersonIdAsync(personId);
        }
        
        public int AddPartOrder(Models.PartOrder partOrder) {
            return base.Channel.AddPartOrder(partOrder);
        }
        
        public System.Threading.Tasks.Task<int> AddPartOrderAsync(Models.PartOrder partOrder) {
            return base.Channel.AddPartOrderAsync(partOrder);
        }
        
        public int AddWarehouse(Models.Warehouse warehouse) {
            return base.Channel.AddWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task<int> AddWarehouseAsync(Models.Warehouse warehouse) {
            return base.Channel.AddWarehouseAsync(warehouse);
        }
        
        public Models.Warehouse GetWarehouse(int id) {
            return base.Channel.GetWarehouse(id);
        }
        
        public System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseAsync(int id) {
            return base.Channel.GetWarehouseAsync(id);
        }
        
        public Models.Warehouse[] GetAllWarehousesByShopId(int shopId) {
            return base.Channel.GetAllWarehousesByShopId(shopId);
        }
        
        public System.Threading.Tasks.Task<Models.Warehouse[]> GetAllWarehousesByShopIdAsync(int shopId) {
            return base.Channel.GetAllWarehousesByShopIdAsync(shopId);
        }
        
        public int UpdateWarehouse(Models.Warehouse warehouse) {
            return base.Channel.UpdateWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task<int> UpdateWarehouseAsync(Models.Warehouse warehouse) {
            return base.Channel.UpdateWarehouseAsync(warehouse);
        }
        
        public int DeleteWarehouse(int id) {
            return base.Channel.DeleteWarehouse(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteWarehouseAsync(int id) {
            return base.Channel.DeleteWarehouseAsync(id);
        }
        
        public int AddSaving(Models.Saving saving, Models.Warehouse warehouse) {
            return base.Channel.AddSaving(saving, warehouse);
        }
        
        public System.Threading.Tasks.Task<int> AddSavingAsync(Models.Saving saving, Models.Warehouse warehouse) {
            return base.Channel.AddSavingAsync(saving, warehouse);
        }
        
        public Models.Saving GetSaving(int id) {
            return base.Channel.GetSaving(id);
        }
        
        public System.Threading.Tasks.Task<Models.Saving> GetSavingAsync(int id) {
            return base.Channel.GetSavingAsync(id);
        }
        
        public int DeleteSaving(int id) {
            return base.Channel.DeleteSaving(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteSavingAsync(int id) {
            return base.Channel.DeleteSavingAsync(id);
        }
        
        public int AddCustomerWithLogin(Models.Customer customer, Models.Login login) {
            return base.Channel.AddCustomerWithLogin(customer, login);
        }
        
        public System.Threading.Tasks.Task<int> AddCustomerWithLoginAsync(Models.Customer customer, Models.Login login) {
            return base.Channel.AddCustomerWithLoginAsync(customer, login);
        }
        
        public Models.Warehouse GetWarehouseByProductId(int productId, int shopId) {
            return base.Channel.GetWarehouseByProductId(productId, shopId);
        }
        
        public System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseByProductIdAsync(int productId, int shopId) {
            return base.Channel.GetWarehouseByProductIdAsync(productId, shopId);
        }
        
        public System.Data.DataTable GetDataGridProducts() {
            return base.Channel.GetDataGridProducts();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetDataGridProductsAsync() {
            return base.Channel.GetDataGridProductsAsync();
        }
        
        public System.Data.DataTable GetProductWareHouse(int adminId) {
            return base.Channel.GetProductWareHouse(adminId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetProductWareHouseAsync(int adminId) {
            return base.Channel.GetProductWareHouseAsync(adminId);
        }
        
        public System.Data.DataTable GetChainData() {
            return base.Channel.GetChainData();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetChainDataAsync() {
            return base.Channel.GetChainDataAsync();
        }
        
        public System.Data.DataTable GetDataGridShop() {
            return base.Channel.GetDataGridShop();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetDataGridShopAsync() {
            return base.Channel.GetDataGridShopAsync();
        }
    }
}
