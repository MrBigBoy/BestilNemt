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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findPerson", ReplyAction="http://tempuri.org/IBestilNemtService/findPersonResponse")]
        Models.Person findPerson(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/findPerson", ReplyAction="http://tempuri.org/IBestilNemtService/findPersonResponse")]
        System.Threading.Tasks.Task<Models.Person> findPersonAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createPerson", ReplyAction="http://tempuri.org/IBestilNemtService/createPersonResponse")]
        void createPerson(Models.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/createPerson", ReplyAction="http://tempuri.org/IBestilNemtService/createPersonResponse")]
        System.Threading.Tasks.Task createPersonAsync(Models.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlPerson", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlPersonResponse")]
        Models.Person[] GetALlPerson();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/GetALlPerson", ReplyAction="http://tempuri.org/IBestilNemtService/GetALlPersonResponse")]
        System.Threading.Tasks.Task<Models.Person[]> GetALlPersonAsync();
        
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
        void DeleteShop(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/DeleteShop", ReplyAction="http://tempuri.org/IBestilNemtService/DeleteShopResponse")]
        System.Threading.Tasks.Task DeleteShopAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        void AddShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddShop", ReplyAction="http://tempuri.org/IBestilNemtService/AddShopResponse")]
        System.Threading.Tasks.Task AddShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        void UpdateShop(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/UpdateShop", ReplyAction="http://tempuri.org/IBestilNemtService/UpdateShopResponse")]
        System.Threading.Tasks.Task UpdateShopAsync(Models.Shop shop);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        Models.Login Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/Login", ReplyAction="http://tempuri.org/IBestilNemtService/LoginResponse")]
        System.Threading.Tasks.Task<Models.Login> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        int AddLogin(string username, string password, int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBestilNemtService/AddLogin", ReplyAction="http://tempuri.org/IBestilNemtService/AddLoginResponse")]
        System.Threading.Tasks.Task<int> AddLoginAsync(string username, string password, int personId);
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
        
        public Models.Person findPerson(int id) {
            return base.Channel.findPerson(id);
        }
        
        public System.Threading.Tasks.Task<Models.Person> findPersonAsync(int id) {
            return base.Channel.findPersonAsync(id);
        }
        
        public void createPerson(Models.Person person) {
            base.Channel.createPerson(person);
        }
        
        public System.Threading.Tasks.Task createPersonAsync(Models.Person person) {
            return base.Channel.createPersonAsync(person);
        }
        
        public Models.Person[] GetALlPerson() {
            return base.Channel.GetALlPerson();
        }
        
        public System.Threading.Tasks.Task<Models.Person[]> GetALlPersonAsync() {
            return base.Channel.GetALlPersonAsync();
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
        
        public void DeleteShop(int id) {
            base.Channel.DeleteShop(id);
        }
        
        public System.Threading.Tasks.Task DeleteShopAsync(int id) {
            return base.Channel.DeleteShopAsync(id);
        }
        
        public void AddShop(Models.Shop shop) {
            base.Channel.AddShop(shop);
        }
        
        public System.Threading.Tasks.Task AddShopAsync(Models.Shop shop) {
            return base.Channel.AddShopAsync(shop);
        }
        
        public void UpdateShop(Models.Shop shop) {
            base.Channel.UpdateShop(shop);
        }
        
        public System.Threading.Tasks.Task UpdateShopAsync(Models.Shop shop) {
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
    }
}
