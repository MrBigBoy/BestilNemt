using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbProduct
    {
        int AddProduct(Product product);
        Product GetProduct(int id);
        List<Product> GetAllProducts();
        List<Product> GetAllSoldProducts();
        List<Product> GetAllProductsWithSavings();
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
        List<Product> GetProductsByName(string input);
    }
}