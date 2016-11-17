using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace Controller
{
    public class ProductCtr
    {
        public IDbProduct DbProduct { get; set; }

        public ProductCtr(IDbProduct dbProduct)
        {
            DbProduct = dbProduct;
        }

        public int AddProduct(Product product)
        {
            return ValidateProductInput(product) ? DbProduct.AddProduct(product) : 0;
        }

        private bool ValidateProductInput(Product product)
        {
            return product?.Name != null && !product.Name.Equals("") && product.Description != null && 
                !product.Description.Equals("") && product.Category != null && !product.Category.Equals("") && 
                product.Price >= 0;
        }

        public int UpdateProduct(Product product)
        {
            return ValidateProductInput(product) ? DbProduct.UpdateProduct(product) : 0;
        }

        public int DeleteProduct(int id)
        {
            return DbProduct.DeleteProduct(id);
        }

        public Product FindProduct(int i)
        {
            return DbProduct.FindProduct(i);
        }

        public List<Product> FindAllProducts()
        {
            return DbProduct.FindAllProducts();
        }
    }
}
