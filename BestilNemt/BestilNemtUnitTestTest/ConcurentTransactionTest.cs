using System.Collections.Generic;
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


        [TestMethod]
        public void TestConcurrencyOneFaild()
        {
            var i1 = 0;
            var i2 = 0;

            var prod = new Product("TestProd", new decimal(10), "TestDescription", "Oste", "TestPath");
            var s = new Shop("TestShop", "TestAddress", "12345678", "OpeningTime", new DbChain().GetChain(1), new List<Warehouse>());

            //add product to database
            int prodId = new DbProduct().AddProduct(prod);
            prod.Id = prodId;
            //add shop to database
            var shopId = new DbShop().AddShop(s);
            s.Id = shopId;

            //add warehouse to databse and add it to shop
            var warehouse = new Warehouse(10, 0, prod, s, null);
            var warId = new DbWarehouse().AddWarehouse(warehouse);
            warehouse.Id = warId;
            s.Warehouses.Add(warehouse);

            //make cart1 with part order
            var cart1 = new Cart();
            var po1 = new PartOrder(prod, 10, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = _cust.Id;
            cart1.ShopId = s.Id;

            //make cart2 with part order
            var cart2 = new Cart();
            var po2 = new PartOrder(prod, 10, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = _cust1.Id;
            cart2.ShopId = s.Id;

            //start 2 parallel queries 
            var cartDb = new DbCart();

            Parallel.Invoke(() => { i1 = cartDb.AddCartWithPartOrders(cart1); }, () => { i2 = cartDb.AddCartWithPartOrders(cart2); });
            var flag = 0;
            if (i1 == 0 || i2 == 0)
                flag = 1;
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void TestConcurrencyBothSuccessfull()
        {
            var i1 = 0;
            var i2 = 0;

            var prod = new Product("TestProd1", new decimal(10), "TestDescription", "Oste", "TestPath");
            var s = new Shop("TestShop1", "TestAddress", "12345678", "OpeningTime", new DbChain().GetChain(1), new List<Warehouse>());

            //add product to database
            int prodId = new DbProduct().AddProduct(prod);
            prod.Id = prodId;
            //add shop to database
            var shopId = new DbShop().AddShop(s);
            s.Id = shopId;

            //add warehouse to databse and add it to shop
            var warehouse = new Warehouse(10, 0, prod, s, null);
            var warId = new DbWarehouse().AddWarehouse(warehouse);
            warehouse.Id = warId;
            s.Warehouses.Add(warehouse);

            //make cart1 with part order
            var cart1 = new Cart();
            var po1 = new PartOrder(prod, 5, 20);
            cart1.PartOrders.Add(po1);
            cart1.PersonId = _cust.Id;
            cart1.ShopId = s.Id;

            //make cart2 with part order
            var cart2 = new Cart();
            var po2 = new PartOrder(prod, 2, 20);
            cart2.PartOrders.Add(po2);
            cart2.PersonId = _cust1.Id;
            cart2.ShopId = s.Id;

            //start 2 parallel queries 
            var cartDb = new DbCart();
            Parallel.Invoke(() => { i1 = cartDb.AddCartWithPartOrders(cart1); }, () => { i2 = cartDb.AddCartWithPartOrders(cart2); });
            var flag = 0;
            if (i1 == 1 && i2 == 1)
                flag = 1;
            Assert.AreEqual(1, flag);
        }
    }
}