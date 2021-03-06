// <copyright file="ShopCtrTest.cs">Copyright ©  2016</copyright>
using System;
using System.Collections.Generic;
using Controller;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Controller.Tests
{
    /// <summary>This class contains parameterized unit tests for ShopCtr</summary>
    [PexClass(typeof(ShopCtr))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ShopCtrTest
    {
        /// <summary>Test stub for AddShop(Shop)</summary>
        [PexMethod]
        public void AddShopTest([PexAssumeUnderTest]ShopCtr target, Shop shop)
        {
            target.AddShop(shop);
            // TODO: add assertions to method ShopCtrTest.AddShopTest(ShopCtr, Shop)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public ShopCtr ConstructorTest()
        {
            ShopCtr target = new ShopCtr();
            return target;
            // TODO: add assertions to method ShopCtrTest.ConstructorTest()
        }

        /// <summary>Test stub for DeleteShop(Int32)</summary>
        [PexMethod]
        public void DeleteShopTest([PexAssumeUnderTest]ShopCtr target, int id)
        {
            target.DeleteShop(id);
            // TODO: add assertions to method ShopCtrTest.DeleteShopTest(ShopCtr, Int32)
        }

        /// <summary>Test stub for GetAllShops()</summary>
        [PexMethod]
        public List<Shop> GetAllShopsTest([PexAssumeUnderTest]ShopCtr target)
        {
            List<Shop> result = target.GetAllShops();
            return result;
            // TODO: add assertions to method ShopCtrTest.GetAllShopsTest(ShopCtr)
        }

        /// <summary>Test stub for GetShop(Int32)</summary>
        [PexMethod]
        public Shop GetShopTest([PexAssumeUnderTest]ShopCtr target, int id)
        {
            Shop result = target.GetShop(id);
            return result;
            // TODO: add assertions to method ShopCtrTest.GetShopTest(ShopCtr, Int32)
        }

        /// <summary>Test stub for UpdateShop(Shop)</summary>
        [PexMethod]
        public void UpdateShopTest([PexAssumeUnderTest]ShopCtr target, Shop shop)
        {
            target.UpdateShop(shop);
            // TODO: add assertions to method ShopCtrTest.UpdateShopTest(ShopCtr, Shop)
        }
    }
}
