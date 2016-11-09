using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbPartOrder
    {
        //int Create(PartOrder partOrder);
        //int RemovePartOrder(int id);
        PartOrder FindPartOrder(int id);
        //List<PartOrder> FindAllPartOrders();
        //int UpdatePartOrder(PartOrder partOrder);
    }
}
