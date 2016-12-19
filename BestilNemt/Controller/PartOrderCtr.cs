using DataAccessLayer;
using Models;

namespace Controller
{
    public class PartOrderCtr
    {
        public IDbPartOrder DbPartOrder { get; set; }

        /// <summary>
        /// The constructor for PartOrder controller
        /// </summary>
        /// <param name="dbPartOrder"></param>
        public PartOrderCtr(IDbPartOrder dbPartOrder)
        {
            DbPartOrder = dbPartOrder;
        }

        /// <summary>
        /// Add a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// Return a PartOrder id if added, else 0
        /// </returns>
        public int AddPartOrder(PartOrder partOrder)
        {
            return ValidatePartOrderInput(partOrder) ? DbPartOrder.AddPartOrder(partOrder) : 0;
        }

        /// <summary>
        /// Validate PartOrder fields
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// True if fields is correct, else false
        /// </returns>
        private static bool ValidatePartOrderInput(PartOrder partOrder)
        {
            return partOrder.Amount > 0 && partOrder.Product != null && partOrder.Cart != null;
        }
    }
}
