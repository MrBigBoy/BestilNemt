using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbWarehouse
    {
        int AddWarehouse(Warehouse warehouse);
        Warehouse FindWarehouse(int id);
        List<Warehouse> FindAllWarehouses();
        int UpdateWarehouse(Warehouse warehouse);
        int DeleteWarehouse(int id);
    }
}