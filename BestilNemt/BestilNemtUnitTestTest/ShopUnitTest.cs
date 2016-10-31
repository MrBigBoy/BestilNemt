using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.ControllerTestClasses;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ShopUnitTest
    {
        /// <summary>
        /// Test a ShopCtr
        /// </summary>
        [TestMethod]
        public void AddShop()
        {
         
            //Test ShopCtr
            //The test is succesfull if cvr is 8 char long => flag ==1 
             
            ShopCtr shopCtr = new ShopCtr(new ShopCtrTestClass());
            var flag = shopCtr.AddShop(new Shop("MiniShop", "Address", "12121212"));
            Assert.AreEqual(1, flag);
        }

        [TestMethod]
        public void AddShopInvalidCvr()
        {
            //Test ShopCtrs
            //The test is succesfull if cvr is not valid and != 8 char long => flag == 0

            ShopCtr shopCtr = new ShopCtr(new ShopCtrTestClass());
            var flag = shopCtr.AddShop(new Shop("NewShop", "NewAddress", "323232"));
            Assert.AreEqual(0, flag);
        }
    }
}
