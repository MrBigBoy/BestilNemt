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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/FindCustomerResponse")]
        Models.Customer FindCustomer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/FindCustomerResponse")]
        System.Threading.Tasks.Task<Models.Customer> FindCustomerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/AddCustomerResponse")]
        int AddCustomer(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/AddCustomerResponse")]
        System.Threading.Tasks.Task<int> AddCustomerAsync(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCustomerResponse")]
        int UpdateCustomer(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCustomerResponse")]
        System.Threading.Tasks.Task<int> UpdateCustomerAsync(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCustomerResponse")]
        int DeleteCustomer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCustomerResponse")]
        System.Threading.Tasks.Task<int> DeleteCustomerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCustomerResponse")]
        Models.Customer[] GetAllCustomer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCustomerResponse")]
        System.Threading.Tasks.Task<Models.Customer[]> GetAllCustomerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/AddAdminResponse")]
        int AddAdmin(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/AddAdminResponse")]
        System.Threading.Tasks.Task<int> AddAdminAsync(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/FindAdminResponse")]
        Models.Admin FindAdmin(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/FindAdminResponse")]
        System.Threading.Tasks.Task<Models.Admin> FindAdminAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllAdmins", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllAdminsResponse")]
        Models.Admin[] GetAllAdmins();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllAdmins", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllAdminsResponse")]
        System.Threading.Tasks.Task<Models.Admin[]> GetAllAdminsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteAdminResponse")]
        int DeleteAdmin(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteAdminResponse")]
        System.Threading.Tasks.Task<int> DeleteAdminAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateAdminResponse")]
        int UpdateAdmin(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateAdminResponse")]
        System.Threading.Tasks.Task<int> UpdateAdminAsync(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        Models.Warehouse GetWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehouses", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesResponse")]
        Models.Warehouse[] GetAllWarehouses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehouses", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesResponse")]
        System.Threading.Tasks.Task<Models.Warehouse[]> GetAllWarehousesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveWarehouseResponse")]
        int RemoveWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveWarehouseResponse")]
        System.Threading.Tasks.Task<int> RemoveWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        int AddWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        System.Threading.Tasks.Task<int> AddWarehouseAsync(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        int UpdateWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        System.Threading.Tasks.Task<int> UpdateWarehouseAsync(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetShopResponse")]
        Models.Shop GetShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetShop", ReplyAction="http://tempuri.org/IBestilNemtService/GetShopResponse")]
        System.Threading.Tasks.Task<Models.Shop> GetShopAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllShops", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllShopsResponse")]
        Models.Shop[] GetAllShops();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllShops", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllShopsResponse")]
        System.Threading.Tasks.Task<Models.Shop[]> GetAllShopsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteShop", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteShopResponse")]
        int DeleteShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteShop", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteShopResponse")]
        System.Threading.Tasks.Task<int> DeleteShopAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        int AddShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        System.Threading.Tasks.Task<int> AddShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        int UpdateShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        System.Threading.Tasks.Task<int> UpdateShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        Models.Login Login([System.ServiceModel.MessageParameterAttribute(Name="login")] Models.Login login1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        System.Threading.Tasks.Task<Models.Login> LoginAsync(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        int AddLogin(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        System.Threading.Tasks.Task<int> AddLoginAsync(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateLogin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateLoginResponse")]
        int UpdateLogin(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateLogin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateLoginResponse")]
        System.Threading.Tasks.Task<int> UpdateLoginAsync(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteLogin", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteLoginResponse")]
        int DeleteLogin(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteLogin", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteLoginResponse")]
        System.Threading.Tasks.Task<int> DeleteLoginAsync(Models.Login login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCompany", ReplyAction="http://tempuri.org/IBestilNemtService/AddCompanyResponse")]
        int AddCompany(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddCompany", ReplyAction="http://tempuri.org/IBestilNemtService/AddCompanyResponse")]
        System.Threading.Tasks.Task<int> AddCompanyAsync(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAllCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindAllCompanyResponse")]
        Models.Company[] FindAllCompany();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAllCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindAllCompanyResponse")]
        System.Threading.Tasks.Task<Models.Company[]> FindAllCompanyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCompany", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCompanyResponse")]
        int DeleteCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCompany", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCompanyResponse")]
        System.Threading.Tasks.Task<int> DeleteCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCompanyResponse")]
        int UpdateCompany(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCompanyResponse")]
        System.Threading.Tasks.Task<int> UpdateCompanyAsync(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindCompanyResponse")]
        Models.Company FindCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindCompanyResponse")]
        System.Threading.Tasks.Task<Models.Company> FindCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddProduct", ReplyAction="http://tempuri.org/IBestilNemtService/AddProductResponse")]
        int AddProduct(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddProduct", ReplyAction="http://tempuri.org/IBestilNemtService/AddProductResponse")]
        System.Threading.Tasks.Task<int> AddProductAsync(Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProduct", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductResponse")]
        Models.Product GetProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetProduct", ReplyAction="http://tempuri.org/IBestilNemtService/GetProductResponse")]
        System.Threading.Tasks.Task<Models.Product> GetProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllProductsResponse")]
        Models.Product[] GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllProducts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllProductsResponse")]
        System.Threading.Tasks.Task<Models.Product[]> GetAllProductsAsync();
        
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCart", ReplyAction="http://tempuri.org/IBestilNemtService/FindCartResponse")]
        Models.Cart FindCart(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCart", ReplyAction="http://tempuri.org/IBestilNemtService/FindCartResponse")]
        System.Threading.Tasks.Task<Models.Cart> FindCartAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCarts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsResponse")]
        Models.Cart[] GetAllCarts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllCarts", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllCartsResponse")]
        System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCart", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCartResponse")]
        int UpdateCart(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCart", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCartResponse")]
        System.Threading.Tasks.Task<int> UpdateCartAsync(Models.Cart cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCart", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCartResponse")]
        int DeleteCart(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteCart", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteCartResponse")]
        System.Threading.Tasks.Task<int> DeleteCartAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/FindPartOrderResponse")]
        Models.PartOrder FindPartOrder(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/FindPartOrderResponse")]
        System.Threading.Tasks.Task<Models.PartOrder> FindPartOrderAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemovePartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/RemovePartOrderResponse")]
        int RemovePartOrder(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemovePartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/RemovePartOrderResponse")]
        System.Threading.Tasks.Task<int> RemovePartOrderAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/AddPartOrderResponse")]
        int AddPartOrder(Models.PartOrder partOrder);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddPartOrder", ReplyAction="http://tempuri.org/IBestilNemtService/AddPartOrderResponse")]
        System.Threading.Tasks.Task<int> AddPartOrderAsync(Models.PartOrder partOrder);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdatePartorder", ReplyAction="http://tempuri.org/IBestilNemtService/UpdatePartorderResponse")]
        int UpdatePartorder(Models.PartOrder partOrder);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdatePartorder", ReplyAction="http://tempuri.org/IBestilNemtService/UpdatePartorderResponse")]
        System.Threading.Tasks.Task<int> UpdatePartorderAsync(Models.PartOrder partOrder);
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
        
        public Models.Customer FindCustomer(int id) {
            return base.Channel.FindCustomer(id);
        }
        
        public System.Threading.Tasks.Task<Models.Customer> FindCustomerAsync(int id) {
            return base.Channel.FindCustomerAsync(id);
        }
        
        public int AddCustomer(Models.Customer customer) {
            return base.Channel.AddCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<int> AddCustomerAsync(Models.Customer customer) {
            return base.Channel.AddCustomerAsync(customer);
        }
        
        public int UpdateCustomer(Models.Customer customer) {
            return base.Channel.UpdateCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<int> UpdateCustomerAsync(Models.Customer customer) {
            return base.Channel.UpdateCustomerAsync(customer);
        }
        
        public int DeleteCustomer(int id) {
            return base.Channel.DeleteCustomer(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteCustomerAsync(int id) {
            return base.Channel.DeleteCustomerAsync(id);
        }
        
        public Models.Customer[] GetAllCustomer() {
            return base.Channel.GetAllCustomer();
        }
        
        public System.Threading.Tasks.Task<Models.Customer[]> GetAllCustomerAsync() {
            return base.Channel.GetAllCustomerAsync();
        }
        
        public int AddAdmin(Models.Admin admin) {
            return base.Channel.AddAdmin(admin);
        }
        
        public System.Threading.Tasks.Task<int> AddAdminAsync(Models.Admin admin) {
            return base.Channel.AddAdminAsync(admin);
        }
        
        public Models.Admin FindAdmin(int id) {
            return base.Channel.FindAdmin(id);
        }
        
        public System.Threading.Tasks.Task<Models.Admin> FindAdminAsync(int id) {
            return base.Channel.FindAdminAsync(id);
        }
        
        public Models.Admin[] GetAllAdmins() {
            return base.Channel.GetAllAdmins();
        }
        
        public System.Threading.Tasks.Task<Models.Admin[]> GetAllAdminsAsync() {
            return base.Channel.GetAllAdminsAsync();
        }
        
        public int DeleteAdmin(int id) {
            return base.Channel.DeleteAdmin(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAdminAsync(int id) {
            return base.Channel.DeleteAdminAsync(id);
        }
        
        public int UpdateAdmin(Models.Admin admin) {
            return base.Channel.UpdateAdmin(admin);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAdminAsync(Models.Admin admin) {
            return base.Channel.UpdateAdminAsync(admin);
        }
        
        public Models.Warehouse GetWarehouse(int id) {
            return base.Channel.GetWarehouse(id);
        }
        
        public System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseAsync(int id) {
            return base.Channel.GetWarehouseAsync(id);
        }
        
        public Models.Warehouse[] GetAllWarehouses() {
            return base.Channel.GetAllWarehouses();
        }
        
        public System.Threading.Tasks.Task<Models.Warehouse[]> GetAllWarehousesAsync() {
            return base.Channel.GetAllWarehousesAsync();
        }
        
        public int RemoveWarehouse(int id) {
            return base.Channel.RemoveWarehouse(id);
        }
        
        public System.Threading.Tasks.Task<int> RemoveWarehouseAsync(int id) {
            return base.Channel.RemoveWarehouseAsync(id);
        }
        
        public int AddWarehouse(Models.Warehouse warehouse) {
            return base.Channel.AddWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task<int> AddWarehouseAsync(Models.Warehouse warehouse) {
            return base.Channel.AddWarehouseAsync(warehouse);
        }
        
        public int UpdateWarehouse(Models.Warehouse warehouse) {
            return base.Channel.UpdateWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task<int> UpdateWarehouseAsync(Models.Warehouse warehouse) {
            return base.Channel.UpdateWarehouseAsync(warehouse);
        }
        
        public Models.Shop GetShop(int id) {
            return base.Channel.GetShop(id);
        }
        
        public System.Threading.Tasks.Task<Models.Shop> GetShopAsync(int id) {
            return base.Channel.GetShopAsync(id);
        }
        
        public Models.Shop[] GetAllShops() {
            return base.Channel.GetAllShops();
        }
        
        public System.Threading.Tasks.Task<Models.Shop[]> GetAllShopsAsync() {
            return base.Channel.GetAllShopsAsync();
        }
        
        public int DeleteShop(int id) {
            return base.Channel.DeleteShop(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteShopAsync(int id) {
            return base.Channel.DeleteShopAsync(id);
        }
        
        public int AddShop(Models.Shop shop) {
            return base.Channel.AddShop(shop);
        }
        
        public System.Threading.Tasks.Task<int> AddShopAsync(Models.Shop shop) {
            return base.Channel.AddShopAsync(shop);
        }
        
        public int UpdateShop(Models.Shop shop) {
            return base.Channel.UpdateShop(shop);
        }
        
        public System.Threading.Tasks.Task<int> UpdateShopAsync(Models.Shop shop) {
            return base.Channel.UpdateShopAsync(shop);
        }
        
        public Models.Login Login(Models.Login login1) {
            return base.Channel.Login(login1);
        }
        
        public System.Threading.Tasks.Task<Models.Login> LoginAsync(Models.Login login) {
            return base.Channel.LoginAsync(login);
        }
        
        public int AddLogin(Models.Login login) {
            return base.Channel.AddLogin(login);
        }
        
        public System.Threading.Tasks.Task<int> AddLoginAsync(Models.Login login) {
            return base.Channel.AddLoginAsync(login);
        }
        
        public int UpdateLogin(Models.Login login) {
            return base.Channel.UpdateLogin(login);
        }
        
        public System.Threading.Tasks.Task<int> UpdateLoginAsync(Models.Login login) {
            return base.Channel.UpdateLoginAsync(login);
        }
        
        public int DeleteLogin(Models.Login login) {
            return base.Channel.DeleteLogin(login);
        }
        
        public System.Threading.Tasks.Task<int> DeleteLoginAsync(Models.Login login) {
            return base.Channel.DeleteLoginAsync(login);
        }
        
        public int AddCompany(Models.Company company) {
            return base.Channel.AddCompany(company);
        }
        
        public System.Threading.Tasks.Task<int> AddCompanyAsync(Models.Company company) {
            return base.Channel.AddCompanyAsync(company);
        }
        
        public Models.Company[] FindAllCompany() {
            return base.Channel.FindAllCompany();
        }
        
        public System.Threading.Tasks.Task<Models.Company[]> FindAllCompanyAsync() {
            return base.Channel.FindAllCompanyAsync();
        }
        
        public int DeleteCompany(int id) {
            return base.Channel.DeleteCompany(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteCompanyAsync(int id) {
            return base.Channel.DeleteCompanyAsync(id);
        }
        
        public int UpdateCompany(Models.Company company) {
            return base.Channel.UpdateCompany(company);
        }
        
        public System.Threading.Tasks.Task<int> UpdateCompanyAsync(Models.Company company) {
            return base.Channel.UpdateCompanyAsync(company);
        }
        
        public Models.Company FindCompany(int id) {
            return base.Channel.FindCompany(id);
        }
        
        public System.Threading.Tasks.Task<Models.Company> FindCompanyAsync(int id) {
            return base.Channel.FindCompanyAsync(id);
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
        
        public Models.Product[] GetAllProducts() {
            return base.Channel.GetAllProducts();
        }
        
        public System.Threading.Tasks.Task<Models.Product[]> GetAllProductsAsync() {
            return base.Channel.GetAllProductsAsync();
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
        
        public Models.Cart FindCart(int id) {
            return base.Channel.FindCart(id);
        }
        
        public System.Threading.Tasks.Task<Models.Cart> FindCartAsync(int id) {
            return base.Channel.FindCartAsync(id);
        }
        
        public Models.Cart[] GetAllCarts() {
            return base.Channel.GetAllCarts();
        }
        
        public System.Threading.Tasks.Task<Models.Cart[]> GetAllCartsAsync() {
            return base.Channel.GetAllCartsAsync();
        }
        
        public int UpdateCart(Models.Cart cart) {
            return base.Channel.UpdateCart(cart);
        }
        
        public System.Threading.Tasks.Task<int> UpdateCartAsync(Models.Cart cart) {
            return base.Channel.UpdateCartAsync(cart);
        }
        
        public int DeleteCart(int id) {
            return base.Channel.DeleteCart(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteCartAsync(int id) {
            return base.Channel.DeleteCartAsync(id);
        }
        
        public Models.PartOrder FindPartOrder(int id) {
            return base.Channel.FindPartOrder(id);
        }
        
        public System.Threading.Tasks.Task<Models.PartOrder> FindPartOrderAsync(int id) {
            return base.Channel.FindPartOrderAsync(id);
        }
        
        public int RemovePartOrder(int id) {
            return base.Channel.RemovePartOrder(id);
        }
        
        public System.Threading.Tasks.Task<int> RemovePartOrderAsync(int id) {
            return base.Channel.RemovePartOrderAsync(id);
        }
        
        public int AddPartOrder(Models.PartOrder partOrder) {
            return base.Channel.AddPartOrder(partOrder);
        }
        
        public System.Threading.Tasks.Task<int> AddPartOrderAsync(Models.PartOrder partOrder) {
            return base.Channel.AddPartOrderAsync(partOrder);
        }
        
        public int UpdatePartorder(Models.PartOrder partOrder) {
            return base.Channel.UpdatePartorder(partOrder);
        }
        
        public System.Threading.Tasks.Task<int> UpdatePartorderAsync(Models.PartOrder partOrder) {
            return base.Channel.UpdatePartorderAsync(partOrder);
        }
    }
}
