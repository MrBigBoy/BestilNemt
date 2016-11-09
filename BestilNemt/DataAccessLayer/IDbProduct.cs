﻿using System.Collections.Generic;
using Models;

namespace DataAccessLayer
{
    public interface IDbProduct
    {
        int AddProduct(Product product);
        Product FindProduct(int id);
        List<Product> FindAllProducts();
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
    }
}