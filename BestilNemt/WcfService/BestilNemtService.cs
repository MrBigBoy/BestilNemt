using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;

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

        public Person findPerson(int id)
        {
            return Personctr.Find(id);
        }

        public void createPerson(Person person)
        {
            Personctr.CreatePerson(person);
        }

        public List<Person> GetALlPerson()
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

        public int DeleteShop(int id)
        {
            return ShopCtr.DeleteShop(id);
        }

        public int AddShop(Shop shop)
        {
           return ShopCtr.AddShop(shop);
        }

        public int UpdateShop(Shop shop)
        {
            return ShopCtr.UpdateShop(shop);
        }
    }
}
