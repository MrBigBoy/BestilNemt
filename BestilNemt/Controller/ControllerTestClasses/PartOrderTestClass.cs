using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class PartOrderTestClass : IDbPartOrder
    {
        private List<PartOrder> PartOrders = new List<PartOrder>();
        private int IdCounter = 1;
        private int Flag = 0;

        public int AddPartOrder(PartOrder partOrder)
        {
            partOrder.Id = IdCounter;
            if (ValidatePartOrderInput(partOrder))
                Flag = 1;

            PartOrders.Add(partOrder);
            IdCounter++;
            return Flag;
        }

        private bool ValidatePartOrderInput(PartOrder partOrder)
        {
            if (partOrder.Amount > 0 && partOrder.Product != null && partOrder.Cart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
