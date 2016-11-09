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
        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for create new Cart object.test is passed if returned value is not 0. AddCart method 
        /// returnes generated id.
        /// </summary>
        [TestMethod]
        public void AddCart()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart = new Cart();
            var flag = cartCtr.AddCart(cart);
            Assert.AreNotEqual(0, flag);
        }

        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for find existing Cart object in collection.test is passed if returned value is not null.
        /// FindCart method returnes Cart object with given id if it exists else returnes null.
        /// </summary>
        [TestMethod]
        public void FindCart()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var cart2 = new Cart(new List<PartOrder>(), 50);
            var id1 = cartCtr.AddCart(cart1);
            var id2 = cartCtr.AddCart(cart2);
            Assert.IsNotNull(cartCtr.FindCart(id1));
        }

        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for find not existing Cart object in collection. Test is passed if returned value is null.
        /// FindCart method returnes Cart object with given id if it exists else returnes null.
        /// </summary>
        [TestMethod]
        public void FindCartFailed()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var cart2 = new Cart(new List<PartOrder>(), 50);
            var id1 = cartCtr.AddCart(cart1);
            var id2 = cartCtr.AddCart(cart2);
            Assert.IsNull(cartCtr.FindCart(10));
        }

        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for updating existing Cart object in collection. Test is passed if updated fields in returned object
        /// are equals expected.
        /// </summary>

        [TestMethod]
        public void UpdateCart()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var id1 = cartCtr.AddCart(cart1);
            Cart cart2 = new Cart(id1, new List<PartOrder>(), 50);
            cartCtr.UpdateCart(cart2);
            Cart updatedCart = cartCtr.FindCart(id1);
            Assert.AreEqual(cart2.TotalPrice, updatedCart.TotalPrice);
        }

        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for delete existing Cart object in collection.test is passed if returned value is 1.
        /// DeleteCart method returnes 1 if the object with given id exists else returnes 0.
        /// </summary>
        [TestMethod]
        public void DeleteCart()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var id1 = cartCtr.AddCart(cart1);
            var flag = cartCtr.DeleteCart(id1);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test of the Cart controller only using CartCtrTestClass that simulates database accses
        /// Test for delete not existing Cart object in collection.test is passed if returned value is 0.
        /// DeleteCart method returnes 1 if the object with given id exists else returnes 0.
        /// </summary>
        [TestMethod]
        public void DeleteCartFail()
        {
            CartCtr cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100);
            var id1 = cartCtr.AddCart(cart1);
            var flag = cartCtr.DeleteCart(0);
            Assert.AreEqual(0, flag);
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
            var cart = new Cart();
            var id = cartDb.AddCart(cart);
            Assert.AreNotEqual(0, id);
        }

        [TestMethod]
        public void FindCartWithDb()
        {
            var cartDb = new DbCart();
           Assert.IsNotNull(cartDb.FindCart(1));
        }

        [TestMethod]
        public void FindAllCartsWithDb()
        {
            var cartDb = new DbCart();
            Assert.AreNotEqual(0, cartDb.GetAllCarts().Count);
        }
    }
}
