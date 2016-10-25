using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        public PersonCtr personctr { get; set; }
        public WarehouseCtr WarehouseController { get; set; }
        public LoginCtr LoginCtr { get; set; }
        public ShopCtr ShopCtr { get; set; }
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr(new DbLogin());
            personctr = new PersonCtr(new DbPerson());
            WarehouseController = new WarehouseCtr(new DbWarehouse());
            ShopCtr = new ShopCtr(new DbShop());
        }

        public Person findPerson(int id)
        {
            return personctr.Find(id);
        }

        public void createPerson(Person person)
        {
            personctr.CreatePerson(person);
        }

        public List<Person> GetALlPerson()
        {
            return personctr.GetAllPerson();
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
            return this.LoginCtr.Login(username, password);
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
    }
}
