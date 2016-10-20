﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using Controller;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BestilNemtService : IBestilNemtService
    {
        public PersonCtr personctr { get; set; }
        public BestilNemtService()
        {
            personctr = new PersonCtr(); 
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

        public WarehouseCtr WarehouseController { get; set; }
        public BestilNemtService()
        {
            WarehouseController = new WarehouseCtr();
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
    }
}
