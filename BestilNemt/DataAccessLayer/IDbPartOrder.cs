using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbPartOrder
    /// </summary>
    public interface IDbPartOrder
    {
        int AddPartOrder(PartOrder partOrder);
    }
}
