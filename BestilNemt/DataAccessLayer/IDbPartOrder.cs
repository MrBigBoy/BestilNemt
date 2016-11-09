using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbPartOrder
    {
        int AddPartOrder(PartOrder partOrder);
        int RemovePartOrder(int id);
        PartOrder FindPartOrder(int id);
        List<PartOrder> GetAllPartOrders();
        int UpdatePartOrder(PartOrder partOrder);
    }
}
