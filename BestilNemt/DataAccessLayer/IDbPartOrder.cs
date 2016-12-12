using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbPartOrder
    /// </summary>
    public interface IDbPartOrder
    {
        int AddPartOrder(PartOrder partOrder);
        //int DeletePartOrder(int id);
        //PartOrder GetPartOrder(int id);
        //List<PartOrder> GetAllPartOrders();
        //int UpdatePartOrder(PartOrder partOrder);
    }
}
