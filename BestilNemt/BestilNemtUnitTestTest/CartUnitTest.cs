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
            var cartCtr = new CartCtr(new CartCtrTestClass());
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
            var cartCtr = new CartCtr(new CartCtrTestClass());
            var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
            var cart2 = new Cart(new List<PartOrder>(), 50, new Person().Id, new Chain().Id);
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
            var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
            var cart2 = new Cart(new List<PartOrder>(), 50, new Person().Id, new Chain().Id);
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
            var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
            var id1 = cartCtr.AddCart(cart1);
            Cart cart2 = new Cart(id1, new List<PartOrder>(), 50, new Person().Id, new Chain().Id);
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
            var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
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
            var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
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

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for find existing object. Test is passed if returned value is not null. FindCart method 
        /// returnes returns Cart object with given id.
        /// </summary>
        [TestMethod]
        public void FindCartWithDb()
        {
            var cartDb = new DbCart();
            Assert.IsNotNull(cartDb.FindCart(1));
        }

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for return a collection of Cart objects. Test is passed if returned collection size is not 0. 
        /// </summary>
        [TestMethod]
        public void FindAllCartsWithDb()
        {
            var cartDb = new DbCart();
            Assert.AreNotEqual(0, cartDb.GetAllCarts().Count);
        }

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for delete existing Cart object from databese. Test is passed if returned value is 1.
        /// DeleteCart method returnes 1 if the entry with given id exists else returnes 0.
        /// </summary>
        [TestMethod]
        public void DeleteCartWithDb()
        {
            var cartDb = new DbCart();
            var cart = new Cart();
            var id = cartDb.AddCart(cart);
            Assert.AreEqual(1, cartDb.DeleteCart(id));
        }

        /// <summary>
        /// Test of the Database accses layer only.
        /// Test for add a partOrder to a Cart. The method AddPartOrderToCart takes cart and partOrder 
        /// objects as parameters and updates partOrder entry with cart.Id
        /// Test is passed if returned value is 1.
        /// DeleteCart method returnes 1 if the entry with given id exists else returnes 0.
        /// </summary>
        [TestMethod]
        public void AddPartOrderToCartWithDb()
        {
            var cartDb = new DbCart();
            var poDb = new DbPartOrder();
            var prodDb = new DbProduct();
            var cart = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
            var id = cartDb.AddCart(cart);
            cart.Id = id;
            var product = new Product("banan", 2, "fjhl", "Frugt", 1, "Img path");
            var prodId = prodDb.AddProduct(product);
            product.Id = prodId;
            var partOrder = poDb.FindPartOrder(1);
            int i = cartDb.AddPartOrderToCart(cart, partOrder);
            Assert.AreEqual(1, i);
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
                var cart = new Cart();
                var id = proxy.AddCart(cart);
                Assert.AreNotEqual(0, id);
            }
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for find Cart object.test is passed if returned object is not null. 
        /// </summary>
        [TestMethod]
        public void FindCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cart = new Cart();
                var id = proxy.AddCart(cart);
                var i = proxy.FindCart(id);
                Assert.IsNotNull(i);
            }
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for all Carts . Test is passed if returned list of objects is not empty. 
        /// </summary>
        [TestMethod]
        public void FindAllCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var i = proxy.GetAllCarts();
                Assert.AreNotEqual(0, i.Length);
            }
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for update total price in Cart. Test is passed if returned value is 1. 
        /// </summary>
        [TestMethod]
        public void UpdateCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
                var id1 = proxy.AddCart(cart1);
                Cart cart2 = new Cart(id1, new List<PartOrder>(), 50, new Person().Id, new Chain().Id);
                var i = proxy.UpdateCart(cart2);
                Cart updatedCart = proxy.FindCart(id1);
                Assert.AreEqual(cart2.TotalPrice, updatedCart.TotalPrice);
            }
        }

        /// <summary>
        /// Test of the WcfCervice.
        /// Test for delete a Cart. Test is passed if returned value is 1. 
        /// </summary>
        [TestMethod]
        public void DeleteCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cart1 = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
                var id1 = proxy.AddCart(cart1);
                var i = proxy.DeleteCart(id1);
                Assert.AreEqual(1, i);
            }
        }

        /// <summary>
        /// Test of the wcf service.
        /// Test for add a partOrder to a Cart using wcf. The method AddPartOrderToCart takes cart and partOrder 
        /// objects as parameters and updates partOrder entry with cart.Id
        /// Test is passed if returned value is 1.
        /// DeleteCart method returnes 1 if the entry with given id exists else returnes 0.
        /// </summary>
        [TestMethod]
        public void AddPartOrderToCartWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var cart = new Cart(new List<PartOrder>(), 100, new Person().Id, new Chain().Id);
                var id = proxy.AddCart(cart);
                cart.Id = id;
                var product = new Product("banan", 2, "fjhl", "Frugt", 1, "Img path");
                var prodId = proxy.AddProduct(product);
                product.Id = prodId;
                var partOrder = proxy.FindPartOrder(1);
                int i = proxy.AddPartOrderToCart(cart, partOrder);
                Assert.AreEqual(1, i);
            }
        }
    }
}
