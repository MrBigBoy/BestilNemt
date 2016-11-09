using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbWarehouse
    {
        int AddWarehouse(Warehouse warehouse);
        int DeleteWarehouse(int id);
        int UpdateWarehouse(Warehouse warehouse);
        List<Warehouse> FindAllWarehouses();
        Warehouse FindWarehouse(int id);
    }
}