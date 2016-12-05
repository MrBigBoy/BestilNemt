using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbPartOrder
    {
        int AddPartOrder(PartOrder partOrder);
        int DeletePartOrder(int id);
        PartOrder GetPartOrder(int id);
        List<PartOrder> GetAllPartOrders();
        int UpdatePartOrder(PartOrder partOrder);
    }
}
