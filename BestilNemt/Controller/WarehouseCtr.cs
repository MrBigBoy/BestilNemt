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
            return DbWarehouse.AddWarehouse(warehouse);
        }

        public Warehouse FindWarehouse(int id)
        {
            return DbWarehouse.FindWarehouse(id);
        }


        public List<Warehouse> FindAllWarehouses()
        {
            return  DbWarehouse.FindAllWarehouses();
        }

     

        public int UpdateWarehouse(Warehouse warehouse)
        {
            return DbWarehouse.UpdateWarehouse(warehouse);
        }

        public int DeleteWarehouse(int id)
        {
            return DbWarehouse.DeleteWarehouse(id);
        }

        //private bool ValidateWarehouse(Warehouse warehouse)
        //{
        //    if (warehouse == null || warehouse.)
        //}
    }
}
