using System.Collections.Generic;
using System.Data;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// Interfaces for DbProduct
    /// </summary>
    public interface IDbProduct
    {
        int AddProduct(Product product);
        Product GetProduct(int id);
        //List<Product> GetAllProducts();
        List<Product> GetAllSoldProducts();
        List<Product> GetAllProductsWithSavings();
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
        List<Product> GetAllProductsByName(string input);
        DataTable GetDataGridProducts();
        DataTable GetProductWarehouse(int adminId);
    }
}