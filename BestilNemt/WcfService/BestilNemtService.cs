using Controller;
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
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr();
            personctr = new PersonCtr();
            WarehouseController = new WarehouseCtr();
        }
        public Person findPerson(int id)
        {
            return personctr.find(id);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void createPerson(Person person)
        {
            personctr.CreatePerson(person);
        }

        public List<Person> GetALlPerson()
        {
            return personctr.GetALlPerson();
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

        public Login Login(string Username, string Password)
        {
            return LoginCtr.Login(Username, Password);
        }
    }
}
