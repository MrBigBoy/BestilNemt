﻿using System;
using System.Text;
using System.Collections.Generic;
using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    /// <summary>
    /// Summary description for SavingUnitTest
    /// </summary>
    [TestClass]
    public class SavingUnitTest
    {
        [TestMethod]
        public void SavingCtrInitialize()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            Assert.IsNotNull(savingCtr);
        }

        [TestMethod]
        public void AddSaving()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory",
                40);
            var saving = new Saving(1, new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50,
                new List<Product>());
            var flag = savingCtr.AddSaving(saving, product);
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void AddSavingNoStartDate()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory",
                40);
            var saving = new Saving(1, new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 0, new List<Product>());
            var flag = savingCtr.AddSaving(saving, product);
            Assert.AreEqual(0, flag);
        }

        [TestMethod]
        public void GetSavingById()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var saving = new Saving(new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50, new List<Product>());
            savingCtr.AddSaving(saving, product);
            Assert.IsNotNull(savingCtr.FindSaving(1));
        }

        [TestMethod]
        public void GetSavingByIdFail()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var saving = new Saving(1, new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50, new List<Product>());
            savingCtr.AddSaving(saving, product);
            Assert.IsNull(savingCtr.FindSaving(2));
        }

        [TestMethod]
        public void FindAllSavings()
        {
            var savingCtr = new SavingCtr(new SavingCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var product2 = new Product(2, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var saving = new Saving(1, new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50, new List<Product>());
            var saving2 = new Saving(2, new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50, new List<Product>());
            savingCtr.AddSaving(saving, product);
            savingCtr.AddSaving(saving2, product2);
            Assert.AreEqual(2, savingCtr.FindAllSavings().Count);
        }

        [TestMethod]
        public void AddAdminCtrDb()
        {
            var savingCtr = new SavingCtr(new DbSaving());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var saving = new Saving(new DateTime(2016, 12, 24), new DateTime(2016, 12, 31), 10.50, new List<Product>());
            var id = savingCtr.AddSaving(saving, product);
            Assert.AreNotEqual(0, id);
        }
    }
}
