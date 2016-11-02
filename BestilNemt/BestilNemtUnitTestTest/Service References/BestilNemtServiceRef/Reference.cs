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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/findCustomerResponse")]
        Models.Customer findCustomer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/findCustomerResponse")]
        System.Threading.Tasks.Task<Models.Customer> findCustomerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/createCustomerResponse")]
        void createCustomer(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/createCustomerResponse")]
        System.Threading.Tasks.Task createCustomerAsync(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/úpdateCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/úpdateCustomerResponse")]
        void úpdateCustomer(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/úpdateCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/úpdateCustomerResponse")]
        System.Threading.Tasks.Task úpdateCustomerAsync(Models.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/removeCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/removeCustomerResponse")]
        void removeCustomer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/removeCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/removeCustomerResponse")]
        System.Threading.Tasks.Task removeCustomerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlCustomerResponse")]
        Models.Customer[] GetALlCustomer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlCustomer", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlCustomerResponse")]
        System.Threading.Tasks.Task<Models.Customer[]> GetALlCustomerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/CreateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/CreateAdminResponse")]
        void CreateAdmin(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/CreateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/CreateAdminResponse")]
        System.Threading.Tasks.Task CreateAdminAsync(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/FindAdminResponse")]
        Models.Admin FindAdmin(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/FindAdminResponse")]
        System.Threading.Tasks.Task<Models.Admin> FindAdminAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllAdmins", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllAdminsResponse")]
        Models.Admin[] GetAllAdmins();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllAdmins", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllAdminsResponse")]
        System.Threading.Tasks.Task<Models.Admin[]> GetAllAdminsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveAdminResponse")]
        int RemoveAdmin(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveAdminResponse")]
        System.Threading.Tasks.Task<int> RemoveAdminAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateAdminResponse")]
        void UpdateAdmin(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateAdmin", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateAdminResponse")]
        System.Threading.Tasks.Task UpdateAdminAsync(Models.Admin admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        Models.Warehouse GetWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/GetWarehouseResponse")]
        System.Threading.Tasks.Task<Models.Warehouse> GetWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehouses", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesResponse")]
        Models.Warehouse[] GetAllWarehouses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetAllWarehouses", ReplyAction="http://tempuri.org/IBestilNemtService/GetAllWarehousesResponse")]
        System.Threading.Tasks.Task<Models.Warehouse[]> GetAllWarehousesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveWarehouseResponse")]
        void RemoveWarehouse(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveWarehouseResponse")]
        System.Threading.Tasks.Task RemoveWarehouseAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        void AddWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/AddWarehouseResponse")]
        System.Threading.Tasks.Task AddWarehouseAsync(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        void UpdateWarehouse(Models.Warehouse warehouse);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateWarehouse", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateWarehouseResponse")]
        System.Threading.Tasks.Task UpdateWarehouseAsync(Models.Warehouse warehouse);
        
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
        Models.Login Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        System.Threading.Tasks.Task<Models.Login> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        int AddLogin(string username, string password, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        System.Threading.Tasks.Task<int> AddLoginAsync(string username, string password, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/CreateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/CreateCompanyResponse")]
        void CreateCompany(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/CreateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/CreateCompanyResponse")]
        System.Threading.Tasks.Task CreateCompanyAsync(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAllCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindAllCompanyResponse")]
        Models.Company[] FindAllCompany();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindAllCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindAllCompanyResponse")]
        System.Threading.Tasks.Task<Models.Company[]> FindAllCompanyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveCompany", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveCompanyResponse")]
        int RemoveCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/RemoveCompany", ReplyAction="http://tempuri.org/IBestilNemtService/RemoveCompanyResponse")]
        System.Threading.Tasks.Task<int> RemoveCompanyAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCompanyResponse")]
        void UpdateCompany(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateCompany", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateCompanyResponse")]
        System.Threading.Tasks.Task UpdateCompanyAsync(Models.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindCompanyResponse")]
        Models.Company FindCompany(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/FindCompany", ReplyAction="http://tempuri.org/IBestilNemtService/FindCompanyResponse")]
        System.Threading.Tasks.Task<Models.Company> FindCompanyAsync(int id);
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
        
        public Models.Customer findCustomer(int id) {
            return base.Channel.findCustomer(id);
        }
        
        public System.Threading.Tasks.Task<Models.Customer> findCustomerAsync(int id) {
            return base.Channel.findCustomerAsync(id);
        }
        
        public void createCustomer(Models.Customer customer) {
            base.Channel.createCustomer(customer);
        }
        
        public System.Threading.Tasks.Task createCustomerAsync(Models.Customer customer) {
            return base.Channel.createCustomerAsync(customer);
        }
        
        public void úpdateCustomer(Models.Customer customer) {
            base.Channel.úpdateCustomer(customer);
        }
        
        public System.Threading.Tasks.Task úpdateCustomerAsync(Models.Customer customer) {
            return base.Channel.úpdateCustomerAsync(customer);
        }
        
        public void removeCustomer(int id) {
            base.Channel.removeCustomer(id);
        }
        
        public System.Threading.Tasks.Task removeCustomerAsync(int id) {
            return base.Channel.removeCustomerAsync(id);
        }
        
        public Models.Customer[] GetALlCustomer() {
            return base.Channel.GetALlCustomer();
        }
        
        public System.Threading.Tasks.Task<Models.Customer[]> GetALlCustomerAsync() {
            return base.Channel.GetALlCustomerAsync();
        }
        
        public void CreateAdmin(Models.Admin admin) {
            base.Channel.CreateAdmin(admin);
        }
        
        public System.Threading.Tasks.Task CreateAdminAsync(Models.Admin admin) {
            return base.Channel.CreateAdminAsync(admin);
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
        
        public int RemoveAdmin(int id) {
            return base.Channel.RemoveAdmin(id);
        }
        
        public System.Threading.Tasks.Task<int> RemoveAdminAsync(int id) {
            return base.Channel.RemoveAdminAsync(id);
        }
        
        public void UpdateAdmin(Models.Admin admin) {
            base.Channel.UpdateAdmin(admin);
        }
        
        public System.Threading.Tasks.Task UpdateAdminAsync(Models.Admin admin) {
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
        
        public void RemoveWarehouse(int id) {
            base.Channel.RemoveWarehouse(id);
        }
        
        public System.Threading.Tasks.Task RemoveWarehouseAsync(int id) {
            return base.Channel.RemoveWarehouseAsync(id);
        }
        
        public void AddWarehouse(Models.Warehouse warehouse) {
            base.Channel.AddWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task AddWarehouseAsync(Models.Warehouse warehouse) {
            return base.Channel.AddWarehouseAsync(warehouse);
        }
        
        public void UpdateWarehouse(Models.Warehouse warehouse) {
            base.Channel.UpdateWarehouse(warehouse);
        }
        
        public System.Threading.Tasks.Task UpdateWarehouseAsync(Models.Warehouse warehouse) {
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
        
        public Models.Login Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<Models.Login> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public int AddLogin(string username, string password, int personId) {
            return base.Channel.AddLogin(username, password, personId);
        }
        
        public System.Threading.Tasks.Task<int> AddLoginAsync(string username, string password, int personId) {
            return base.Channel.AddLoginAsync(username, password, personId);
        }
        
        public void CreateCompany(Models.Company company) {
            base.Channel.CreateCompany(company);
        }
        
        public System.Threading.Tasks.Task CreateCompanyAsync(Models.Company company) {
            return base.Channel.CreateCompanyAsync(company);
        }
        
        public Models.Company[] FindAllCompany() {
            return base.Channel.FindAllCompany();
        }
        
        public System.Threading.Tasks.Task<Models.Company[]> FindAllCompanyAsync() {
            return base.Channel.FindAllCompanyAsync();
        }
        
        public int RemoveCompany(int id) {
            return base.Channel.RemoveCompany(id);
        }
        
        public System.Threading.Tasks.Task<int> RemoveCompanyAsync(int id) {
            return base.Channel.RemoveCompanyAsync(id);
        }
        
        public void UpdateCompany(Models.Company company) {
            base.Channel.UpdateCompany(company);
        }
        
        public System.Threading.Tasks.Task UpdateCompanyAsync(Models.Company company) {
            return base.Channel.UpdateCompanyAsync(company);
        }
        
        public Models.Company FindCompany(int id) {
            return base.Channel.FindCompany(id);
        }
        
        public System.Threading.Tasks.Task<Models.Company> FindCompanyAsync(int id) {
            return base.Channel.FindCompanyAsync(id);
        }
    }
}
