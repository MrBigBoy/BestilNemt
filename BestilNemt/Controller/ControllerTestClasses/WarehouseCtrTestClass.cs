using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class WarehouseCtrTestClass: IDbWarehouse
    {
        private List<Warehouse> warehouses = new List<Warehouse>();
        private int idCounter = 1;
        public int AddWarehouse(Warehouse warehouse)
        {
            warehouse.Id = idCounter;
            warehouses.Add(warehouse);
            idCounter++;
            return warehouse.Id;
        }

        public Warehouse FindWarehouse(int id)
        {
            return warehouses.FirstOrDefault(w => w.Id == id);
        }

        public List<Warehouse> FindAllWarehouses()
        {
            return warehouses;
        }

        public List<Warehouse> FindAllWarehousesByShopId(int shopId)
        {
            return warehouses.Where(w => w.Shop.Id == shopId).ToList();
        }

        public int UpdateWarehouse(Warehouse warehouse)
        {
            var returnedWarehouse = FindWarehouse(warehouse.Id);
            returnedWarehouse.Stock = warehouse.Stock;
            returnedWarehouse.MinStock = warehouse.Stock;
            returnedWarehouse.Shop = warehouse.Shop;
            returnedWarehouse.Product = warehouse.Product;
            return 1;
        }

        public int DeleteWarehouse(int id)
        {
            return warehouses.Remove(FindWarehouse(id)) ? 1 : 0;

        }

       
    }
}
