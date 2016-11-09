using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class PartOrderCtr
    {
        public IDbPartOrder DbPartOrder { get; set; }

        public PartOrderCtr(IDbPartOrder dbPartOrder)
        {
            DbPartOrder = dbPartOrder;
        }

        //public int AddPartOrder(PartOrder partOrder)
        //{
        //    return ValidatePartOrderInput(partOrder) ? DbPartOrder.create(partOrder) : 0;
        //}

        public PartOrder FindPartOrder(int id)
        {
            return DbPartOrder.FindPartOrder(id);
        }

        private bool ValidatePartOrderInput(PartOrder partOrder)
        {
            return partOrder?.Amount != null && partOrder?.Product != null && partOrder?.Cart != null;
        }

        public int UpdatePartorder(PartOrder partOrder)
        {
            
            return ValidatePartOrderInput(partOrder) ? DbPartOrder.UpdatePartOrder(partOrder): 0;
        }
    }
}
