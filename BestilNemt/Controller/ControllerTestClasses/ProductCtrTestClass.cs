using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int RemoveProduct(int id)
        {
            return products.Remove(FindProduct(id)) ? 1 : 0;
        }

        public Product FindProduct(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> FindAllProducts()
        {
            return products;
        }

        public int UpdateProduct(Product product)
        {
            var returnedProduct = FindProduct(product.Id);
            returnedProduct.Name = product.Name;
            returnedProduct.Price = product.Price;
            returnedProduct.Category = product.Category;
            returnedProduct.Description = product.Description;
            returnedProduct.Saving = product.Saving;
            return 1;
        }

        public int DeleteProduct(int id)
        {
            return products.Remove(FindProduct(id)) ? 1 : 0;
        }
    }
}
