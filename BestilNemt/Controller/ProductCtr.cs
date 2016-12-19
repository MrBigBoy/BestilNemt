using System.Collections.Generic;
using System.Data;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class ProductCtr
    {
        public IDbProduct DbProduct { get; set; }

        /// <summary>
        /// The constructor for Product controller
        /// </summary>
        /// <param name="dbProduct"></param>
        public ProductCtr(IDbProduct dbProduct)
        {
            DbProduct = dbProduct;
        }

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Return id of Product, else 0
        /// </returns>
        public int AddProduct(Product product)
        {
            return ValidateProductInput(product) ? DbProduct.AddProduct(product) : 0;
        }

        /// <summary>
        /// Method to validate Product Fields
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// True if fields is correct, else false
        /// </returns>
        private static bool ValidateProductInput(Product product)
        {
            return !string.IsNullOrEmpty(product?.Name) && !string.IsNullOrEmpty(product.Description) &&
                !string.IsNullOrEmpty(product.Category) && product.Price >= 0;
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// 1 if updated, else 0
        /// </returns>
        public int UpdateProduct(Product product)
        {
            return ValidateProductInput(product) ? DbProduct.UpdateProduct(product) : 0;
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if deleted, else 0
        /// </returns>
        public int DeleteProduct(int id)
        {
            return DbProduct.DeleteProduct(id);
        }

        /// <summary>
        /// Get a Product
        /// </summary>
        /// <param name="i"></param>
        /// <returns>
        /// Product if found, else null
        /// </returns>
        public Product GetProduct(int i)
        {
            return DbProduct.GetProduct(i);
        }

        ///// <summary>
        ///// Get all Products
        ///// </summary>
        ///// <returns>
        ///// List of Products
        ///// </returns>
        //public List<Product> GetAllProducts()
        //{
        //    return DbProduct.GetAllProducts();
        //}

        ///// <summary>
        ///// Get all Product starting with the Name
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns>
        ///// List of Product
        ///// </returns>
        //public List<Product> GetAllProductsByName(string input)
        //{
        //    return DbProduct.GetAllProductsByName(input);
        //}

        /// <summary>
        /// Get all sold products
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllSoldProducts()
        {
            return DbProduct.GetAllSoldProducts();
        }

        /// <summary>
        /// Get all products with a Saving
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProductsWithSavings()
        {
            return DbProduct.GetAllProductsWithSavings();
        }

        public DataTable GetDataGridProducts()
        {
            return DbProduct.GetDataGridProducts();
        }

        public DataTable GetProductWareHouse(int adminId)
        {
            return DbProduct.GetProductWarehouse(adminId);
        }
    }
}
