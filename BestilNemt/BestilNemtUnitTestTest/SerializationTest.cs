using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void TestPersonIdSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop,"Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestPersonNameSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestPersonEmailSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestPersonAddresSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopIdSER()
        {
            Person person = new Person();
            Warehouse warehouse = new Warehouse();
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", person, warehouse);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.id, serializationResult.id);
        }
        [TestMethod]
        public void TestShopNameSER()
        {
            Person person = new Person();
            Warehouse warehouse = new Warehouse();
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", person, warehouse);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestShopAddresSER()
        {
            Person person = new Person();
            Warehouse warehouse = new Warehouse();
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", person, warehouse);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopCVRSER()
        {
            Person person = new Person();
            Warehouse warehouse = new Warehouse();
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", person, warehouse);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.CVR, serializationResult.CVR);
        }
        [TestMethod]
        public void TestWarehouseIdSER()
        {
            Product product = new Product();
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, product, shop);
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestWarehouseStockSER()
        {
            Product product = new Product();
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, product, shop);
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Stock, serializationResult.Stock);
        }

        [TestMethod]
        public void TestWarehouseMinStockSER()
        {
            Product product = new Product();
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, product, shop);
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.MinStock, serializationResult.MinStock);
        }
        [TestMethod]

        public void TestLoginIdSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestLoginUserNameSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Username, serializationResult.Username);
        }
        [TestMethod]
        public void TestLoginPasswordSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Password, serializationResult.Password);
        }
        [TestMethod]
        public void TestProductIdSER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr",10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestProductNameSER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", 10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestProductCatecorySER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", 10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Category, serializationResult.Category);
        }
        [TestMethod]
        public void TestProductDescriptionSER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", 10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Description, serializationResult.Description);
        }
        [TestMethod]
        public void TestProductSavingSER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", 10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Saving, serializationResult.Saving);
        }
        [TestMethod]
        public void TestProductPriceSER()
        {
            Warehouse warehouse = new Warehouse();
            Product product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", 10.50, warehouse);
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Price, serializationResult.Price);
        }
        [TestMethod]
        public void TestPartOrderIdSER()
        {
            Product product = new Product();
            Cart cart = new Cart();
            PartOrder partOrder = new PartOrder(2, product, 2, 100m, cart);
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestPartOrderAmountSER()
        {
            Product product = new Product();
            Cart cart = new Cart();
            PartOrder partOrder = new PartOrder(2, product, 2, 100m, cart);
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.Amount, serializationResult.Amount);
        }
        [TestMethod]
        public void TestPartOrderPartPriceSER()
        {
            Product product = new Product();
            Cart cart = new Cart();
            PartOrder partOrder = new PartOrder(2, product, 2, 100m, cart);
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.PartPrice, serializationResult.PartPrice);
        }
        [TestMethod]
        public void TestCartIdSER()
        {
            PartOrder partOrder = new PartOrder();
            Cart cart = new Cart(5, partOrder, 200.00m);
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.Id, serializationResult.Id);
        }

        public void TestCartTotalPriceSER()
        {
            PartOrder partOrder = new PartOrder();
            Cart cart = new Cart(5, partOrder, 200.00m);
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.TotalPrice, serializationResult.TotalPrice);
        }





    }
}
