using Controller;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using Controller;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        public PersonCtr personctr { get; set; }
        public WarehouseCtr WarehouseController { get; set; }
        public BestilNemtService()
        {
            personctr = new PersonCtr();
            WarehouseController = new WarehouseCtr();
        }
        public Person findPerson(int id)
        {
            return personctr.find(id);
        }

        private SqlConnection Connection { get; set; }

        public SqlConnection GetConnection()
        {
            if(Connection == null)
            {
                Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString);
            }
            return Connection;
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
