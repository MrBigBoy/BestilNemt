﻿using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class WarehouseCtrTestClass : IDbWarehouse
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

        public Warehouse GetWarehouse(int id)
        {
            return warehouses.FirstOrDefault(w => w.Id == id);
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return warehouses;
        }

        public List<Warehouse> GetAllWarehousesByShopId(int shopId)
        {
            return warehouses.Where(w => w.Shop.Id == shopId).ToList();
        }

        public int UpdateWarehouse(Warehouse warehouse)
        {
            var returnedWarehouse = GetWarehouse(warehouse.Id);
            returnedWarehouse.Stock = warehouse.Stock;
            returnedWarehouse.MinStock = warehouse.Stock;
            returnedWarehouse.Shop = warehouse.Shop;
            returnedWarehouse.Product = warehouse.Product;
            return 1;
        }

        public Warehouse GetWarehouseByProductId(int productId, int shopId)
        {
            return new Warehouse();
        }

        public int DeleteWarehouse(int id)
        {
            return warehouses.Remove(GetWarehouse(id)) ? 1 : 0;
        }
    }
}
