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

        public void Add(Warehouse warehouse)
        {
            DbWarehouse.Add(warehouse);
        }
        public Warehouse Get(int id)
        {
            return DbWarehouse.Get(id);
        }

        public List<Warehouse> GetAll()
        {
            return DbWarehouse.GetAll();
        }

        public void Remove(int id)
        {
            DbWarehouse.Remove(id);
        }

        public void Update(Warehouse warehouse)
        {
            DbWarehouse.Update(warehouse);
        }
    }
}
