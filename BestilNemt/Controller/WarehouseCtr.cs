using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;

namespace Controller
{
    public class WarehouseCtr
    {
        public DbWarehouse Warehouses { get; set; }

        public WarehouseCtr()
        {
            Warehouses = new DbWarehouse();
        }

        public void Add(Warehouse warehouse)
        {
            Warehouses.Add(warehouse);
        }
        public Warehouse Get(int id)
        {
            return Warehouses.Get(id);
        }

        public List<Warehouse> GetAll()
        {
            return Warehouses.GetAll();
        }

        public void Remove(int id)
        {
            Warehouses.Remove(id);
        }

        public void Update(Warehouse warehouse)
        {
            Warehouses.Update(warehouse);
        }
    }
}
