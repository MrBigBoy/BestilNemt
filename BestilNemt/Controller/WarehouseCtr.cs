using System.Collections.Generic;
using Models;
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
            return warehouse.Chain != null && warehouse.Chain.Id != 0 && warehouse.Product != null &&
                   warehouse.Product.Id != 0
                ? DbWarehouse.AddWarehouse(warehouse)
                : 0;
        }
        public Warehouse FindWarehouse(int id)
        {
            return DbWarehouse.FindWarehouse(id);
        }

        public List<Warehouse> FindAllWarehouses()
        {
            return DbWarehouse.FindAllWarehouses();
        }

        public int DeleteWarehouse(int id)
        {
            return DbWarehouse.DeleteWarehouse(id);
        }

        public int UpdateWarehouse(Warehouse warehouse)
        {
            return DbWarehouse.UpdateWarehouse(warehouse);
        }
    }
}
