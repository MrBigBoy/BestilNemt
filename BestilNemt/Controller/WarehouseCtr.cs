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
           return DbWarehouse.FindWarehouse(id);
            
          }


        public List<Warehouse> FindAllWarehouses()
        {
           return DbWarehouse.FindAllWarehouses();
          }

        public List<Warehouse> FindAllWarehousesByShopId(int shopId)
        {
            return DbWarehouse.FindAllWarehousesByShopId(shopId);
           
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