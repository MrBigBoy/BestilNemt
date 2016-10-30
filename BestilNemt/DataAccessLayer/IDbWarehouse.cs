using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbWarehouse
    {
        int Add(Warehouse warehouse);
        int Remove(int id);
        int Update(Warehouse warehouse);
        List<Warehouse> GetAll();
        Warehouse Get(int id);
    }
}