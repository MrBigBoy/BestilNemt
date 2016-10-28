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
            Person person = new Person(4,"Benny","HotforFuck@hotmail.com","Kattevejen");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person); 
            Assert.AreEqual(person.Id,serializationResult.Id);
        }
        [TestMethod]
        public void TestPersonNameSER()
        {
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestPersonEmailSER()
        {
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestPersonAddresSER()
        {
            Person person = new Person(4, "Benny", "HotforFuck@hotmail.com", "Kattevejen");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopIdSER()
        {
            Shop shop = new Shop();
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Id, serializationResult.Id);
        }
        public void TestShopNameSER()
        {
            Shop shop = new Shop();
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Name, serializationResult.Name);
        }
        public void TestShopAddresSER()
        {
            Shop shop = new Shop();
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Address, serializationResult.Address);
        }
        public void TestShopCVRSER()
        {
            Shop shop = new Shop();
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.CVR, serializationResult.CVR);
        }
        public void TestWarehouseIdSER()
        {
            Warehouse warehouse = new Warehouse();
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Id, serializationResult.Id);
        }
        public void TestWarehouseStockSER()
        {
            Warehouse warehouse = new Warehouse();
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Stock, serializationResult.Stock);
        }
        public void TestWarehouseMinStockSER()
        {
            Warehouse warehouse = new Warehouse();
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.MinStock, serializationResult.MinStock);
        }
        public void TestLoginIdSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Id, serializationResult.Id);
        }
        public void TestLoginUserNameSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Username, serializationResult.Username);
        }
        public void TestLoginPasswordSER()
        {
            Login login = new Login();
            Login serializationResult = SerializerTestHelpClass.TestSerialize<Login>(login);
            Assert.AreEqual(login.Password, serializationResult.Password);
        }
        public void TestProductIdSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Id, serializationResult.Id);
        }
        public void TestProductNameSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Name, serializationResult.Name);
        }
        public void TestProductCatecorySER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Category, serializationResult.Category);
        }
        public void TestProductDescriptionSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Description, serializationResult.Description);
        }
        public void TestProductSavingSER()
        {
            Product product = new Product();
            Product serializationResult = SerializerTestHelpClass.TestSerialize<Product>(product);
            Assert.AreEqual(product.Description, serializationResult.Description);
        }






    }
}
