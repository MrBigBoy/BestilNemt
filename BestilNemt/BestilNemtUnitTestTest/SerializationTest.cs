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
            Person person = new Person(4,"Benny","HotforFuck@hotmail.com","Kattevejen", login, shop);
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person); 
            Assert.AreEqual(person.Id,serializationResult.Id);
        }
        [TestMethod]
        public void TestPersonNameSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop);
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestPersonEmailSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop);
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestPersonAddresSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen", login, shop);
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopIdSER()
        {
            Shop shop = new Shop(5,"Rema","VimmerVej","3323232");
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.id, serializationResult.id);
        }
        [TestMethod]
        public void TestShopNameSER()
        {
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232");
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestShopAddresSER()
        {
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232");
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopCVRSER()
        {
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232");
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.CVR, serializationResult.CVR);
        }
        [TestMethod]
        public void TestWarehouseIdSER()
        {
            Product product = new Product();
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3,3,2,product,shop);
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
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestProductNameSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestProductCatecorySER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Category, serializationResult.Category);
        }
        [TestMethod]
        public void TestProductDescriptionSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Description, serializationResult.Description);
        }
        [TestMethod]
        public void TestProductSavingSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Saving, serializationResult.Saving);
        }
        [TestMethod]
        public void TestProductPriceSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Price, serializationResult.Price);
        }
        [TestMethod]
        public void TestPartOrderIdSER()
        {
            PartOrder partOrder = new PartOrder();
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestPartOrderAmountSER()
        {
            PartOrder partOrder = new PartOrder();
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.Amount, serializationResult.Amount);
        }
        [TestMethod]
        public void TestPartOrderPartPriceSER()
        {
            PartOrder partOrder = new PartOrder();
            PartOrder serializationResult = SerializerTestHelpClass.TestSerialize<PartOrder>(partOrder);
            Assert.AreEqual(partOrder.PartPrice, serializationResult.PartPrice);
        }
        [TestMethod]
        public void TestCartIdSER()
        {
            Cart cart = new Cart();
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.Id, serializationResult.Id);
        }

        public void TestCartTotalPriceSER()
        {
            Cart cart = new Cart();
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.TotalPrice, serializationResult.TotalPrice);
        }





    }
}
