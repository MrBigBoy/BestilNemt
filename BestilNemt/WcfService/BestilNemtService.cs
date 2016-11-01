using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        public PersonCtr Personctr { get; set; }
        public WarehouseCtr WarehouseController { get; set; }
        public LoginCtr LoginCtr { get; set; }
        public ShopCtr ShopCtr { get; set; }
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr(new DbLogin());
            Personctr = new PersonCtr(new DbPerson());
            WarehouseController = new WarehouseCtr(new DbWarehouse());
            ShopCtr = new ShopCtr(new DbShop());
        }

        public Customer findCustomer(int id)
        {
            return Personctr.Find(id);
        }

        public void createCustomer(Customer customer)
        {
            Personctr.CreatePerson(customer);
        }

        public List<Customer> GetALlCustomer()
        {
            return Personctr.GetAllPerson();
        }

        public Warehouse GetWarehouse(int id)
        {
            return WarehouseController.Get(id);
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return WarehouseController.GetAll();
        }

        public void RemoveWarehouse(int id)
        {
            WarehouseController.Remove(id);
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            WarehouseController.Add(warehouse);
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            WarehouseController.Update(warehouse);
        }

        public Login Login(string username, string password)
        {
            return LoginCtr.Login(username, password);
        }

        public int AddLogin(string username, string password, int personId)
        {
            return LoginCtr.AddLogin(username, password, personId);
        }

        public Shop GetShop(int id)
        {
            return ShopCtr.GetShop(id);
        }

        public List<Shop> GetAllShops()
        {
            return ShopCtr.GetAllShops();
        }

        public void DeleteShop(int id)
        {
            ShopCtr.DeleteShop(id);
        }

        public void AddShop(Shop shop)
        {
            ShopCtr.AddShop(shop);
        }

        public void UpdateShop(Shop shop)
        {
            ShopCtr.UpdateShop(shop);
        }

        public void removeCustomer(int id)
        {
            Personctr.RemoveCustomer(id);
        }

        public void úpdateCustomer(Customer customer)
        {
            Personctr.updateCustomer(customer); 
        }
    }
}
