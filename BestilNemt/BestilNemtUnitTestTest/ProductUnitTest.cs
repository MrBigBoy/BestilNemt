using Controller;
using Controller.ControllerTestClasses;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace BestilNemtUnitTestTest
{
    [TestClass]
    public class ProductUnitTest
    {
        /// <summary>
        /// Test a ProductCtr constructor
        /// The test is successfull if the instance is not null
        /// </summary>
        [TestMethod]
        public void ChainCtrInitialize()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            Assert.IsNotNull(productCtr);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 1
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void AddProductCtr()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing name, null value
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailName()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(null, 23.45m, "The product description", "The product catagory", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing name, empty string
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailName2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("", 23.45m, "The product description", "The product catagory", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing description, null value
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailDescription()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 23.45m, null, "The product catagory", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing description, empty string
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailDescription2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 23.45m, "", "The product catagory", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing catagory, null value
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailCategory()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 23.45m, "The product description", null, 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing catagory, empty string
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailCategory2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 23.45m, "The product description", "", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Price lower than 0
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailPrice()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", -1m, "The product description", "", 40);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr Addproduct
        /// The test is successfull if the flag is 0
        /// ERROR: Saving lower than 0
        /// </summary>
        [TestMethod]
        public void AddProductCtrFailSaving()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 2m, "The product description", "", -10);
            var flag = productCtr.AddProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a DbProduct Addproduct
        /// The test is successfull if the flag is not 0
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void AddProductDb()
        {
            var dbProduct = new DbProduct();
            var product = new Product("The product name", 23.45m, "The product description", "The product catagory", 1);
            var flag = dbProduct.AddProduct(product);
            Assert.AreNotEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr FindProduct
        /// The test is successfull if the flag is not null
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void FindProductCtr()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product name", 23.45m, "The product description", "The product catagory", 40);
            productCtr.AddProduct(product);
            var flag = productCtr.FindProduct(1);
            Assert.IsNotNull(flag);
        }

        /// <summary>
        /// Test a ProductCtr FindAllProducts
        /// The test is successfull if the flag is not null
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void FindAllProductCtr()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product1 = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", 40);
            productCtr.AddProduct(product1);
            var product2 = new Product("The product2 name", 34.56m, "The product2 description", "The product2 catagory", 50);
            productCtr.AddProduct(product2);
            var product3 = new Product("The product3 name", 45.67m, "The product3 description", "The product3 catagory", 60);
            productCtr.AddProduct(product3);
            var products = productCtr.FindAllProducts();
            Assert.AreEqual(3, products.Count);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 1
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void UpdateProductCtr()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "The product catagory", 40);
            productCtr.AddProduct(product);
            product = new Product(1, "The product new name", 34.56m, "The product new description", "The product new catagory", 50);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing name, null value
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailName()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, null, 23.45m, "The product description", "The product catagory", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing name, empty string
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailName2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "", 23.45m, "The product description", "The product catagory", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing description, null value
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailDescription()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, null, "The product catagory", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing description, empty string
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailDescription2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "", "The product catagory", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing catagory, null value
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailCategory()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", null, 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Missing catagory, empty string
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailCategory2()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 23.45m, "The product description", "", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Price lower than 0
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailPrice()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", -1m, "The product description", "", 40);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr UpdateProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Saving lower than 0
        /// </summary>
        [TestMethod]
        public void UpdateProductCtrFailSaving()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product(1, "The product name", 2m, "The product description", "", -10);
            var flag = productCtr.UpdateProduct(product);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductCtr DeleteProduct
        /// The test is successfull if the flag is 1
        /// ERROR: Non
        /// </summary>
        [TestMethod]
        public void DeleteProductCtr()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", 40);
            var flag = productCtr.AddProduct(product);
            flag = productCtr.DeleteProduct(flag);
            Assert.AreEqual(1, flag);
        }

        /// <summary>
        /// Test a ProductCtr DeleteProduct
        /// The test is successfull if the flag is 0
        /// ERROR: Id is 0
        /// </summary>
        [TestMethod]
        public void DeleteProductCtrFail()
        {
            var productCtr = new ProductCtr(new ProductCtrTestClass());
            var flag = productCtr.DeleteProduct(0);
            Assert.AreEqual(0, flag);
        }

        /// <summary>
        /// Test a ProductWcf DeleteProduct
        /// The test is successfull if the flag is not 0
        /// ERROR: Id is 0
        /// </summary>
        [TestMethod]
        public void AddProductWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", 40);
                var i = proxy.AddProduct(product);
                proxy.DeleteProduct(i);
                Assert.AreNotEqual(0, i);
            }
        }

        /// <summary>
        /// Test a ProductWcf DeleteProduct
        /// The test is successfull if the flag is 1
        /// ERROR: Id is 0
        /// </summary>
        [TestMethod]
        public void UpdateProductWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", 40);
                var id = proxy.AddProduct(product);
                product.Id = id;
                var i = proxy.UpdateProduct(product);
                proxy.DeleteProduct(id);
                Assert.AreEqual(1, i);
            }
        }


        /// <summary>
        /// Test a ProductWcf DeleteProduct
        /// The test is successfull if the flag is 1
        /// ERROR: Id is 0
        /// </summary>
        [TestMethod]
        public void DeleteProductWcf()
        {
            using (var proxy = new BestilNemtServiceRef.BestilNemtServiceClient())
            {
                proxy.Open();
                var product = new Product("The product1 name", 23.45m, "The product1 description", "The product1 catagory", 40);
                var id = proxy.AddProduct(product);
                var i = proxy.DeleteProduct(id);
                Assert.AreEqual(1, i);
            }
        }
    }
}
