using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbWarehouse
    {
        void Add(Warehouse warehouse);
        void Remove(int id);
        void Update(Warehouse warehouse);
        List<Warehouse> GetAll();
        Warehouse Get(int id);
    }
}