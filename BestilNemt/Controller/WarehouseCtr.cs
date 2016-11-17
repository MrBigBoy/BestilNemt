using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Controller
{
    public class WarehouseCtr
    { 
       // private readonly Exception NotFoundExeption =  new Exception("Warehouse was not found");
    

        public IDbWarehouse DbWarehouse { get; set; }

        public WarehouseCtr(IDbWarehouse dbWarehouse)
        {
            DbWarehouse = dbWarehouse;
        }

        public int AddWarehouse(Warehouse warehouse)
        {
            return ValidateWarehouse(warehouse) ? DbWarehouse.AddWarehouse(warehouse) : 0;
        }

        public Warehouse FindWarehouse(int id)
        {
            var warehouse = DbWarehouse.FindWarehouse(id);
            if (warehouse == null)
                throw  new NullReferenceException();
            return warehouse;
        }


        public List<Warehouse> FindAllWarehouses()
        {
            var warehouses = DbWarehouse.FindAllWarehouses();
            if (warehouses.Count == 0)
                throw new NullReferenceException();
            return warehouses;
        }

        public List<Warehouse> FindAllWarehousesByShopId(int shopId)
        {
            var warehouses = DbWarehouse.FindAllWarehousesByShopId(shopId);
            if (warehouses.Count == 0)
                throw new NullReferenceException();
            return warehouses;
        }


        public int UpdateWarehouse(Warehouse warehouse)
        {
            return ValidateWarehouse(warehouse) ? DbWarehouse.UpdateWarehouse(warehouse) : 0;
        }

        public int DeleteWarehouse(int id)
        {
            return DbWarehouse.DeleteWarehouse(id);
        }

        private bool ValidateWarehouse(Warehouse warehouse)
        {
            if (warehouse == null || warehouse.MinStock < 0 || warehouse.Stock < 0 || warehouse.Shop == null)
                return false;
            return true;
        }

       
    }
}