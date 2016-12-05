using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ConcurentTransactionTest
    {

        private Customer cust = new DbCustomer().GetCustomer(1);
        private Customer cust1 = new DbCustomer().GetCustomer(5);
        private Product prod = new DbProduct().GetProduct(1);


        [TestMethod]
        public void TestConcurrencyOneFaild()
        {
            var i1 = 0;
            var i2 = 0;
            DbWarehouse dbW = new DbWarehouse();
            Shop s = new DbShop().GetShop(1);
            Warehouse w = new Warehouse(1, 10, 0, prod, s);
            dbW.UpdateWarehouse(w);
            Parallel.Invoke(() => { i1 = StartTr1(); }, () => { i2 = StartTr2(); });
            var flag = 0;
            if (i1 == 0 || i2 == 0)
                flag = 1;
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void TestConcurrencyBothSuccsesfull()
        {
            DbWarehouse dbW = new DbWarehouse();
            Shop s = new DbShop().GetShop(1);
            Warehouse w = new Warehouse(1, 10, 0, prod, s);
            dbW.UpdateWarehouse(w);
            Parallel.Invoke(() => { StartTr3(); }, () => { StartTr4(); });
            var stock = dbW.GetWarehouse(1).Stock;
            Assert.AreEqual(3, stock);
        }
        private int StartTr1()
        {
            DbCart cartDb = new DbCart();
            Cart cart = MakeCart1();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private int StartTr2()
        {
            DbCart cartDb = new DbCart();
            Cart cart = MakeCart2();
            return cartDb.AddCartWithPartOrders(cart);
        }
        private int StartTr3()
        {
            DbCart cartDb = new DbCart();
            Cart cart = MakeCart3();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private int StartTr4()
        {
            DbCart cartDb = new DbCart();
            Cart cart = MakeCart4();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private Cart MakeCart1()
        {
            Cart cart1 = new Cart();
            PartOrder po1 = new PartOrder(prod, 10, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = cust.Id;
            return cart1;
        }

        private Cart MakeCart2()
        {
            Cart cart2 = new Cart();
            PartOrder po2 = new PartOrder(prod, 10, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = cust1.Id;
            return cart2;
        }
        private Cart MakeCart3()
        {
            Cart cart1 = new Cart();
            PartOrder po1 = new PartOrder(prod, 5, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = cust.Id;
            return cart1;
        }

        private Cart MakeCart4()
        {
            Cart cart2 = new Cart();
            PartOrder po2 = new PartOrder(prod, 2, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = cust1.Id;
            return cart2;
        }
    }
}