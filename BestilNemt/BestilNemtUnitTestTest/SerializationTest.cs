﻿using System;
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
        public void TestCustomerIdSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, chains, "Customer");
            var serializationResult = SerializerTestHelpClass.TestSerialize(customer);
            Assert.AreEqual(customer.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestCustomerNameSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, chains, "Customer");
            var serializationResult = SerializerTestHelpClass.TestSerialize(customer);
            Assert.AreEqual(customer.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestCustomerEmailSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, chains, "Customer");
            var serializationResult = SerializerTestHelpClass.TestSerialize(customer);
            Assert.AreEqual(customer.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestCustomerAddresSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, chains, "Customer");
            var serializationResult = SerializerTestHelpClass.TestSerialize(customer);
            Assert.AreEqual(customer.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestCustomerBirthdaySer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var customer = new Customer(4, "Benny", "benny@hotmail.com", "Kattevejen", new DateTime(2000, 02, 01), login, chains, "Customer");
            var serializationResult = SerializerTestHelpClass.TestSerialize(customer);
            Assert.AreEqual(customer.Birthday, serializationResult.Birthday);
        }

        [TestMethod]
        public void TestAdminIdSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain> { chain };
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestAdminNameSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain>();
            chains.Add(chain);
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestAdminEmailSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain>();
            chains.Add(chain);
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.Email, serializationResult.Email);
        }
        [TestMethod]
        public void TestAdminAddressSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain>();
            chains.Add(chain);
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.Address, serializationResult.Address);
        }
        [TestMethod]
        public void TestAdminPersonTypeSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain>();
            chains.Add(chain);
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.PersonType, serializationResult.PersonType);
        }
        [TestMethod]
        public void TestAdminMemNrSer()
        {
            var login = new Login();
            var chain = new Chain();
            var chains = new List<Chain>();
            chains.Add(chain);
            var admin = new Admin(4, "Benny", "benny@hotmail.com", "Kattevejen", login, chains, "Administrator", 1, 1);
            var serializationResult = SerializerTestHelpClass.TestSerialize(admin);
            Assert.AreEqual(admin.Membernr, serializationResult.Membernr);
        }
        [TestMethod]
        public void TestChainIdSer()
        {
            var person = new Person();
            var persons = new List<Person>();
            persons.Add(person);
            var shop = new Shop();
            var shops = new List<Shop>();
            shops.Add(shop);
            var chain = new Chain(5, "Rema", "3323232", "Img path", persons, shops);
            var serializationResult = SerializerTestHelpClass.TestSerialize(chain);
            Assert.AreEqual(chain.Id, serializationResult.Id);
        }

        [TestMethod]
        public void TestChainNameSer()
        {
            var person = new Person();
            var persons = new List<Person>();
            persons.Add(person);
            var shop = new Shop();
            var shops = new List<Shop>();
            shops.Add(shop);
            var chain = new Chain(5, "Rema", "3323232", "Img path", persons, shops);
            var serializationResult = SerializerTestHelpClass.TestSerialize(chain);
            Assert.AreEqual(chain.Name, serializationResult.Name);
        }

        [TestMethod]
        public void TestChainCvrser()
        {
            var person = new Person();
            var persons = new List<Person>();
            persons.Add(person);
            var shop = new Shop();
            var shops = new List<Shop>();
            shops.Add(shop);
            var chain = new Chain(5, "Rema", "3323232", "Img path", persons, shops);
            var serializationResult = SerializerTestHelpClass.TestSerialize(chain);
            Assert.AreEqual(chain.Cvr, serializationResult.Cvr);
        }

        [TestMethod]
        public void TestShopIdSer()
        {
            var warehouses = new List<Warehouse>();
            var chain = new Chain();
            var shop = new Shop(3, "name", "Address", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "long cvr", chain, warehouses);
            var serializationResult = SerializerTestHelpClass.TestSerialize(shop);
            Assert.AreEqual(shop.Id, serializationResult.Id);
        }

        [TestMethod]
        public void TestShopNameSer()
        {
            var warehouses = new List<Warehouse>();
            var chain = new Chain();
            var shop = new Shop(3, "name", "Address", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "long cvr", chain, warehouses);
            var serializationResult = SerializerTestHelpClass.TestSerialize(shop);
            Assert.AreEqual(shop.Name, serializationResult.Name);
        }

        [TestMethod]
        public void TestShopAddressSer()
        {
            var warehouses = new List<Warehouse>();
            var chain = new Chain();
            var shop = new Shop(3, "name", "Address", "Mandag - Torsdag	08:00 - 21:00;Fredag  08:00 - 22:00;Lørdag - Søndag 08:00 - 21:00", "long cvr", chain, warehouses);
            var serializationResult = SerializerTestHelpClass.TestSerialize(shop);
            Assert.AreEqual(shop.Address, serializationResult.Address);
        }
        [TestMethod]

        public void TestLoginIdSer()
        {
            var login = new Login();
            var serializationResult = SerializerTestHelpClass.TestSerialize(login);
            Assert.AreEqual(login.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestLoginUserNameSer()
        {
            var login = new Login();
            var serializationResult = SerializerTestHelpClass.TestSerialize(login);
            Assert.AreEqual(login.Username, serializationResult.Username);
        }
        [TestMethod]
        public void TestLoginPasswordSer()
        {
            var login = new Login();
            var serializationResult = SerializerTestHelpClass.TestSerialize(login);
            Assert.AreEqual(login.Password, serializationResult.Password);
        }
        [TestMethod]
        public void TestProductIdSer()
        {
            var product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", "Img path");
            var serializationResult = SerializerTestHelpClass.TestSerialize(product);
            Assert.AreEqual(product.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestProductNameSer()
        {
            var product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", "Img path");
            var serializationResult = SerializerTestHelpClass.TestSerialize(product);
            Assert.AreEqual(product.Name, serializationResult.Name);
        }
        [TestMethod]
        public void TestProductCatecorySer()
        {
            var product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", "Img path");
            var serializationResult = SerializerTestHelpClass.TestSerialize(product);
            Assert.AreEqual(product.Category, serializationResult.Category);
        }
        [TestMethod]
        public void TestProductDescriptionSer()
        {
            var product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", "Img path");
            var serializationResult = SerializerTestHelpClass.TestSerialize(product);
            Assert.AreEqual(product.Description, serializationResult.Description);
        }

        [TestMethod]
        public void TestProductPriceSer()
        {
            var product = new Product(3, "Kat", 20.50m, "Stor kat", "Dyr", "Img path");
            var serializationResult = SerializerTestHelpClass.TestSerialize(product);
            Assert.AreEqual(product.Price, serializationResult.Price);
        }
        [TestMethod]
        public void TestPartOrderIdSer()
        {
            var product = new Product();
            var cart = new Cart();
            var partOrder = new PartOrder(2, product, 2, 100m, cart);
            var serializationResult = SerializerTestHelpClass.TestSerialize(partOrder);
            Assert.AreEqual(partOrder.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestPartOrderAmountSer()
        {
            var product = new Product();
            var cart = new Cart();
            var partOrder = new PartOrder(2, product, 2, 100m, cart);
            var serializationResult = SerializerTestHelpClass.TestSerialize(partOrder);
            Assert.AreEqual(partOrder.Amount, serializationResult.Amount);
        }
        [TestMethod]
        public void TestPartOrderPartPriceSer()
        {
            var product = new Product();
            var cart = new Cart();
            var partOrder = new PartOrder(2, product, 2, 100m, cart);
            var serializationResult = SerializerTestHelpClass.TestSerialize(partOrder);
            Assert.AreEqual(partOrder.PartPrice, serializationResult.PartPrice);
        }
        [TestMethod]
        public void TestCartIdSer()
        {
            var partOrder = new PartOrder();
            var partOrders = new List<PartOrder> { partOrder };
            var cart = new Cart(5, partOrders, 200.00m, new Person().Id, new Chain().Id);
            var serializationResult = SerializerTestHelpClass.TestSerialize(cart);
            Assert.AreEqual(cart.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestCartTotalPriceSer()
        {
            var partOrder = new PartOrder();
            var partOrders = new List<PartOrder> { partOrder };
            var cart = new Cart(5, partOrders, 200.00m, new Person().Id, new Chain().Id);
            var serializationResult = SerializerTestHelpClass.TestSerialize(cart);
            Assert.AreEqual(cart.TotalPrice, serializationResult.TotalPrice);
        }
        [TestMethod]
        public void TestWareHouseMinStockSer()
        {
            var wareHouse = new Warehouse(2, 32, 10);
            var serializationResult = SerializerTestHelpClass.TestSerialize(wareHouse);
            Assert.AreEqual(wareHouse.MinStock, serializationResult.MinStock);
        }
        [TestMethod]
        public void TestWareHouseIdSer()
        {
            var wareHouse = new Warehouse(2, 32, 10);
            var serializationResult = SerializerTestHelpClass.TestSerialize(wareHouse);
            Assert.AreEqual(wareHouse.Id, serializationResult.Id);
        }
        [TestMethod]
        public void TestWareHouseStockSer()
        {
            var wareHouse = new Warehouse(2, 32, 10);
            var serializationResult = SerializerTestHelpClass.TestSerialize(wareHouse);
            Assert.AreEqual(wareHouse.Stock, serializationResult.Stock);
        }

        [TestMethod]
        public void TestSavingStartDateSer()
        {
            var product = new Product();
            var products = new List<Product> { product };
            var saving = new Saving(new DateTime(2000, 02, 01), new DateTime(2000, 02, 01), 2.1, products);
            var serializationResult = SerializerTestHelpClass.TestSerialize(saving);
            Assert.AreEqual(saving.StartDate, serializationResult.StartDate);
        }
        [TestMethod]
        public void TestSavingÉndDateSer()
        {
            var product = new Product();
            var products = new List<Product> { product };
            var saving = new Saving(new DateTime(2000, 02, 01), new DateTime(2000, 02, 01), 2.1, products);
            var serializationResult = SerializerTestHelpClass.TestSerialize(saving);
            Assert.AreEqual(saving.EndDate, serializationResult.EndDate);
        }
        [TestMethod]
        public void TestSavingSavingPercentSer()
        {
            var product = new Product();
            var products = new List<Product> { product };
            var saving = new Saving(new DateTime(2000, 02, 01), new DateTime(2000, 02, 01), 2.1, products);
            var serializationResult = SerializerTestHelpClass.TestSerialize(saving);
            Assert.AreEqual(saving.SavingPercent, serializationResult.SavingPercent);
        }
    }
}
