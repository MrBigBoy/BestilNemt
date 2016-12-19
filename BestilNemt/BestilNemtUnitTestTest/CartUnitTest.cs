using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class CartUnitTest
    {
        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for create new Cart object.test is passed if returned value is not 0. AddCart method 
        /// returnes generated id.
        /// </summary>
        [TestMethod]
        public void AddCart()
        {
            var cartCtr = new CartCtr(new CartCtrTestClass());
            var cart = new Cart();
            var flag = cartCtr.AddCart(cart);
            Assert.AreNotEqual(0, flag);
        }

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for create new Cart object.test is passed if returned value is not 0. AddCart method 
        /// returnes generated id.
        /// </summary>
        [TestMethod]
        public void AddCartWithDb()
        {
            var cartDb = new DbCart();
            var cart = new Cart
            {
                PersonId = 1,
                ShopId = 1,
                TotalPrice = new decimal(5)
            };
            var id = cartDb.AddCart(cart);
            Assert.AreNotEqual(0, id);
        }

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for return a collection of Cart objects. Test is passed if returned collection size is not 0. 
        /// </summary>
        [TestMethod]
        public void GetAllCartsWithDb()
        {
            var cartDb = new DbCart();
            Assert.AreNotEqual(0, cartDb.GetAllCarts().Count);
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for create new Cart object.test is passed if returned value is not 0. AddCart method 
        /// returnes generated id.
        /// </summary>
        [TestMethod]
        public void AddCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cart = new Cart
                {
                    ShopId = 1,
                    PersonId = 1,
                    TotalPrice = new decimal(5)
                };
                var id = proxy.AddCart(cart);
                Assert.AreNotEqual(0, id);
            }
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for all Carts . Test is passed if returned list of objects is not empty. 
        /// </summary>
        [TestMethod]
        public void GetAllCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.GetAllCarts();
                Assert.AreNotEqual(0, i.Length);
            }
        }
    }
}
