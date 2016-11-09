using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class WarehouseCtrTestClass : IDbWarehouse
    {
        List<Warehouse> warehouses = new List<Warehouse>();
        private int idCounter = 1;

        public int AddWarehouse(Warehouse warehouse)
        {
            warehouse.Id = idCounter;
            warehouses.Add(warehouse);
            idCounter++;
            return warehouse.Id;
        }

        public int DeleteWarehouse(int id)
        {
            return warehouses.Remove(FindWarehouse(id)) ? 1 : 0;
        } 

        public int UpdateWarehouse(Warehouse warehouse)
        {
            var returnedWarehouse = FindWarehouse(warehouse.Id);
            returnedWarehouse.MinStock = warehouse.MinStock;
            returnedWarehouse.Stock = warehouse.Stock;
            returnedWarehouse.Shop = warehouse.Shop;
            returnedWarehouse.Product = warehouse.Product;
            return 1;
        }

        public List<Warehouse> FindAllWarehouses()
        {
            return warehouses;
        }

        public Warehouse FindWarehouse(int id)
        {
            return warehouses.FirstOrDefault(warehouse => warehouse.Id == id);
        }
    }
}
