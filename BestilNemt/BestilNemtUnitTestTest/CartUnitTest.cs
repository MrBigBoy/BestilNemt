using System.Collections.Generic;
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
        [TestMethod]
        public void AddCart()
        {
            var cartCtr = new CartCtr(new CartCtrTestClass());
            var cart = new Cart();
            var flag = cartCtr.AddCart(cart);
            Assert.AreNotEqual(0, flag);
        }

        [TestMethod]
        public void FindCart()
        {
            var cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var cart2 = new Cart(new List<PartOrder>(), 50);
            var id1 = cartCtr.AddCart(cart1);
            var id2 = cartCtr.AddCart(cart2);
            Assert.IsNotNull(cartCtr.FindCart(id1));
        }





    }
}
