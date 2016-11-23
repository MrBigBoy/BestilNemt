using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbProduct
    {
        int AddProduct(Product product);
        Product FindProduct(int id);
        List<Product> FindAllProducts();
        List<Product> FindAllSoldProducts();
        List<Product> FindAllProductsWithSavings();
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
        List<Product> FindProductsByName(string input);
    }
}