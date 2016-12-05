using System.Collections.Generic;
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
        /// Get a PartOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// PartOrder if found, else null
        /// </returns>
        public PartOrder GetPartOrder(int id)
        {
            return DbPartOrder.GetPartOrder(id);

        }

        /// <summary>
        /// Get all PartOrders
        /// </summary>
        /// <returns>
        /// List of PartOrder
        /// </returns>
        public List<PartOrder> GetAllPartOrders()
        {
            return DbPartOrder.GetAllPartOrders();
        }

        /// <summary>
        /// Delete a PartOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if deleted, else 0
        /// </returns>
        public int DeletePartOrder(int id)
        {
            return DbPartOrder.DeletePartOrder(id);
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

        /// <summary>
        /// Update a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// 1 if updated, else 0
        /// </returns>
        public int UpdatePartOrder(PartOrder partOrder)
        {
            return ValidatePartOrderInput(partOrder) ? DbPartOrder.UpdatePartOrder(partOrder) : 0;
        }
    }
}
