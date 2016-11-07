using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class SerializationTest
    {
        //These tests are do the same basic thing. They create object, serialize them and then tests if they still are the same
        [TestMethod]
        public void TestCustomerIdSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Customer customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, shops,"Customer");
            Customer serializationResult = SerializerTestHelpClass.TestSerialize<Customer>(customer);
            Assert.AreEqual(customer.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestPersonNameSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Person person = new Person(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestPersonEmailSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Person person = new Person(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestPersonAddresSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Person person = new Person(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Admin");
            Person serializationResult = SerializerTestHelpClass.TestSerialize<Person>(person);
            Assert.AreEqual(person.Address, serializationResult.Address);
        }

        [TestMethod]
        public void TestCompanyIdSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops,"Company",1234567,1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestCompanyNameSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestCompanyEmailSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestCompanyAddressSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestCompanyPersonTypeSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.PersonType, serializationResult.PersonType);
        }
        [TestMethod]
        public void TestCompanyCVRSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.CVR, serializationResult.CVR);
        }
        [TestMethod]
        public void TestCompanyKonNrSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Company company = new Company(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Company", 1234567, 1);
            Company serializationResult = SerializerTestHelpClass.TestSerialize<Company>(company);
            Assert.AreEqual(company.Kontonr, serializationResult.Kontonr);
        }

        [TestMethod]
        public void TestAdminIdSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestAdminNameSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestAdminEmailSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestAdminAddressSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestAdminPersonTypeSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.PersonType, serializationResult.PersonType);
        }
        [TestMethod]
        public void TestAdminMemNrSER()
        {
            Login login = new Login();
            Shop shop = new Shop();
            List<Shop> shops = new List<Shop>();
            shops.Add(shop);
            Admin admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, shops, "Administrator", 1);
            Admin serializationResult = SerializerTestHelpClass.TestSerialize<Admin>(admin);
            Assert.AreEqual(admin.Membernr, serializationResult.Membernr);
        }
        [TestMethod]
        public void TestShopIdSER()
        {
            Person person = new Person();
            List<Person> persons = new List<Person>();
            persons.Add(person);
            Warehouse warehouse = new Warehouse();
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses.Add(warehouse);
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", persons, warehouses);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestShopNameSER()
        {
            Person person = new Person();
            List<Person> persons = new List<Person>();
            persons.Add(person);
            Warehouse warehouse = new Warehouse();
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses.Add(warehouse);
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", persons, warehouses);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestShopAddresSER()
        {
            Person person = new Person();
            List<Person> persons = new List<Person>();
            persons.Add(person);
            Warehouse warehouse = new Warehouse();
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses.Add(warehouse);
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", persons, warehouses);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestShopCVRSER()
        {
            Person person = new Person();
            List<Person> persons = new List<Person>();
            persons.Add(person);
            Warehouse warehouse = new Warehouse();
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses.Add(warehouse);
            Shop shop = new Shop(5, "Rema", "VimmerVej", "3323232", persons, warehouses);
            Shop serializationResult = SerializerTestHelpClass.TestSerialize<Shop>(shop);
            Assert.AreEqual(shop.CVR, serializationResult.CVR);
        }
        [TestMethod]
        public void TestWarehouseIdSER()
        {
            Product product = new Product();
            List<Product> products = new List<Product>();
            products.Add(product);
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, products, shop);
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestWarehouseStockSER()
        {
            Product product = new Product();
            List<Product> products = new List<Product>();
            products.Add(product);
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, products, shop);
            Warehouse serializationResult = SerializerTestHelpClass.TestSerialize<Warehouse>(warehouse);
            Assert.AreEqual(warehouse.Stock, serializationResult.Stock);
        }

        [TestMethod]
        public void TestWarehouseMinStockSER()
        {
            Product product = new Product();
            List<Product> products = new List<Product>();
            products.Add(product);
            Shop shop = new Shop();
            Warehouse warehouse = new Warehouse(3, 3, 2, products, shop);
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
            List<PartOrder> partOrders = new List<PartOrder>();
            partOrders.Add(partOrder);
            Cart cart = new Cart(5, partOrders, 200.00m);
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.Id, serializationResult.Id);
        }

        public void TestCartTotalPriceSER()
        {
            PartOrder partOrder = new PartOrder();
            List<PartOrder> partOrders = new List<PartOrder>();
            partOrders.Add(partOrder);
            Cart cart = new Cart(5, partOrders, 200.00m);
            Cart serializationResult = SerializerTestHelpClass.TestSerialize<Cart>(cart);
            Assert.AreEqual(cart.TotalPrice, serializationResult.TotalPrice);
        }
    }
}
