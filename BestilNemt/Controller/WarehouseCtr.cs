using Models;
using System.Collections.Generic;
using DataAccessLayer;

namespace Controller
{
    public class WarehouseCtr
    {
        public IDbWarehouse DbWarehouse { get; set; }

        /// <summary>
        /// Constructor of Warehouse controller
        /// </summary>
        /// <param name="dbWarehouse"></param>
        public WarehouseCtr(IDbWarehouse dbWarehouse)
        {
            DbWarehouse = dbWarehouse;
        }

        /// <summary>
        /// Add a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// id of Warehouse if added, else 0
        /// </returns>
        public int AddWarehouse(Warehouse warehouse)
        {
            return ValidateWarehouse(warehouse) ? DbWarehouse.AddWarehouse(warehouse) : 0;
        }

        /// <summary>
        /// Get a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouse(int id)
        {
            return DbWarehouse.GetWarehouse(id);
        }

        /// <summary>
        /// Get all warehouses
        /// </summary>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> GetAllWarehouses()
        {
            return DbWarehouse.GetAllWarehouses();
        }

        /// <summary>
        /// Get all warehouses by Shop Id
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public List<Warehouse> GetAllWarehousesByShopId(int shopId)
        {
            return DbWarehouse.GetAllWarehousesByShopId(shopId);
        }

        /// <summary>
        /// Update a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// 1 if Warehouse is updated, else 0
        /// </returns>
        public int UpdateWarehouse(Warehouse warehouse)
        {
            return ValidateWarehouse(warehouse) ? DbWarehouse.UpdateWarehouse(warehouse) : 0;
        }

        /// <summary>
        /// Delete a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if Warehouse is deleted, else 0
        /// </returns>
        public int DeleteWarehouse(int id)
        {
            return DbWarehouse.DeleteWarehouse(id);
        }

        /// <summary>
        /// Validate of Warehouse fields
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// true if Warehouse fields is correct, else false
        /// </returns>
        private static bool ValidateWarehouse(Warehouse warehouse)
        {
            return warehouse != null && warehouse.MinStock >= 0 && warehouse.Stock >= 0 && warehouse.Shop != null;
        }
    }
}