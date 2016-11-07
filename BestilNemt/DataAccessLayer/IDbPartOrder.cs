using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface IDbPartOrder
    {
        int Create(PartOrder partOrder);
        int RemovePartOrder(int id);
        PartOrder FindPartOrder(int id);
        List<PartOrder> FindAllPartOrders();
        int UpdatePartOrder(PartOrder partOrder);
    }
}
