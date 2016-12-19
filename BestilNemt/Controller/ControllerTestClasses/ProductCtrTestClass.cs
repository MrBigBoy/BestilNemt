using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer;
using Models;

namespace Controller.ControllerTestClasses
{
    public class ProductCtrTestClass : IDbProduct
    {
        private List<Product> products = new List<Product>();
        private int idCounter = 1;

        public int AddProduct(Product product)
        {
            product.Id = idCounter;
            products.Add(product);
            return idCounter++;
        }
        
        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetAllSoldProducts()
        {
            return products;
        }

        public List<Product> GetAllProductsWithSavings()
        {
            return products;
        }

        public int UpdateProduct(Product product)
        {
            var returnedProduct = GetProduct(product.Id);
            returnedProduct.Name = product.Name;
            returnedProduct.Price = product.Price;
            returnedProduct.Category = product.Category;
            returnedProduct.Description = product.Description;
            return 1;
        }

        public int DeleteProduct(int id)
        {
            return products.Remove(GetProduct(id)) ? 1 : 0;
        }

        public List<Product> GetAllProductsByName(string input)
        {
            return products.FindAll(product => product.Name == input);
        }

        public DataTable GetDataGridProducts()
        {
            return new DataTable();
        }

        public DataTable GetProductWarehouse(int adminId)
        {
            return new DataTable();
        }
    }
}
