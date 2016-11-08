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

        public int Add(Warehouse warehouse)
        {
            return DbWarehouse.Add(warehouse);
        }
        public Warehouse Get(int id)
        {
            return DbWarehouse.Get(id);
        }

        public List<Warehouse> GetAll()
        {
            return DbWarehouse.GetAll();
        }

        public int Remove(int id)
        {
            return DbWarehouse.Remove(id);
        }

        public int Update(Warehouse warehouse)
        {
            return DbWarehouse.Update(warehouse);
        }
    }
}
