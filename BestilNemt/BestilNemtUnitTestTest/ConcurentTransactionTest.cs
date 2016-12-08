using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ConcurentTransactionTest
    {

        private readonly Customer _cust = new DbCustomer().GetCustomer(1);
        private readonly Customer _cust1 = new DbCustomer().GetCustomer(4);
        private readonly Product _prod = new DbProduct().GetProduct(1);
        
        private readonly Shop _s = new Shop("TestShop", "TestAddress", "12345678", "OpeningTime", new DbChain().GetChain(1), new List<Warehouse>());

        [TestMethod]
        public void TestConcurrencyOneFaild()
        {
            var i1 = 0;
            var i2 = 0;
            var dbW = new DbWarehouse();
            var w = new Warehouse(1, 10, 0, _prod, _s);
            dbW.UpdateWarehouse(w);
            Parallel.Invoke(() => { i1 = StartTr1(); }, () => { i2 = StartTr2(); });
            var flag = 0;
            if (i1 == 0 || i2 == 0)
                flag = 1;
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void TestConcurrencyBothSuccessfull()
        {
            var dbW = new DbWarehouse();
            var w = new Warehouse(1, 10, 0, _prod, _s);
            dbW.UpdateWarehouse(w);
            Parallel.Invoke(() => { StartTr3(); }, () => { StartTr4(); });
            var stock = dbW.GetWarehouse(1).Stock;
            Assert.AreEqual(3, stock);
        }
        private int StartTr1()
        {
            var cartDb = new DbCart();
            var cart = MakeCart1();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private int StartTr2()
        {
            var cartDb = new DbCart();
            var cart = MakeCart2();
            return cartDb.AddCartWithPartOrders(cart);
        }
        private int StartTr3()
        {
            var cartDb = new DbCart();
            var cart = MakeCart3();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private int StartTr4()
        {
            var cartDb = new DbCart();
            var cart = MakeCart4();
            return cartDb.AddCartWithPartOrders(cart);
        }

        private Cart MakeCart1()
        {
            var cart1 = new Cart();
            var po1 = new PartOrder(_prod, 10, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = _cust.Id;
            cart1.ShopId = _s.Id;
            return cart1;
        }

        private Cart MakeCart2()
        {
            var cart2 = new Cart();
            var po2 = new PartOrder(_prod, 10, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = _cust1.Id;
            cart2.ShopId = _s.Id;
            return cart2;
        }
        private Cart MakeCart3()
        {
            var cart1 = new Cart();
            var po1 = new PartOrder(_prod, 5, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = _cust.Id;
            cart1.ShopId = _s.Id;
            return cart1;
        }

        private Cart MakeCart4()
        {
            var cart2 = new Cart();
            var po2 = new PartOrder(_prod, 2, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = _cust1.Id;
            cart2.ShopId = _s.Id;
            return cart2;
        }
    }
}