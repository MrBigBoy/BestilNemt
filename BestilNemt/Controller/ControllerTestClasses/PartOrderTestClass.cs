using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int RemovePartOrder(int id)
        {
            return PartOrders.Remove(FindPartOrder(id)) ? 1 : 0;
        }

        public PartOrder FindPartOrder(int id)
        {
            return PartOrders.FirstOrDefault(PartOrders => PartOrders.Id == id);
        }

        public List<PartOrder> GetAllPartOrders()
        {
            return PartOrders;
        }

        public int UpdatePartOrder(PartOrder partOrder)
        {
            var returnedPartOrder = FindPartOrder(partOrder.Id);
            returnedPartOrder.Amount = partOrder.Amount;
            returnedPartOrder.PartPrice = partOrder.PartPrice;

            return 1;
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
