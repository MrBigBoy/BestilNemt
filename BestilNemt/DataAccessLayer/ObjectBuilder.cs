using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class ObjectBuilder
    {

        public static Product CreateProduct(SqlDataReader reader)
        {
            var product = new Product
            {
                Id = reader.GetInt32(reader.GetOrdinal("productId")),
                Name = reader.GetString(reader.GetOrdinal("productName")),
                Price = reader.GetDecimal(reader.GetOrdinal("productPrice")),
                Description = reader.GetString(reader.GetOrdinal("productDescription")),
                Category = reader.GetString(reader.GetOrdinal("productCategory")),
                Saving = reader.GetDouble(reader.GetOrdinal("productSaving"))
            };
            return product;
        }

        public static Admin CreateAdmin(SqlDataReader reader)
        {
            var admin = new Admin()
            {
                Id = reader.GetInt32(reader.GetOrdinal("personId")),
                Name = reader.GetString(reader.GetOrdinal("personName")),
                Email = reader.GetString(reader.GetOrdinal("personEmail")),
                Address = reader.GetString(reader.GetOrdinal("personAddress")),
                PersonType = reader.GetString(reader.GetOrdinal("personType")),
                Membernr = reader.GetInt32(reader.GetOrdinal("administratorMemberNr"))
            };
            return admin;
        }

        public static Cart CreateCart(SqlDataReader reader)
        {
            var cart = new Cart
            {
                Id = reader.GetInt32(reader.GetOrdinal("cartId")),
                TotalPrice = reader.GetDecimal(reader.GetOrdinal("cartTotalPrice")),
            };
            return cart;
        }

        public static Company CreateCompany(SqlDataReader reader)
        {
            var company = new Company()
            {
                Id = reader.GetInt32(reader.GetOrdinal("personId")),
                Name = reader.GetString(reader.GetOrdinal("personName")),
                Email = reader.GetString(reader.GetOrdinal("personEmail")),
                Address = reader.GetString(reader.GetOrdinal("personAddress")),
                PersonType = reader.GetString(reader.GetOrdinal("personType")),
                CVR = reader.GetInt32(reader.GetOrdinal("companyCVR")),
                Kontonr = reader.GetInt32(reader.GetOrdinal("companyKontoNr"))
            };
            return company;
        }

        public static Customer CreateCustomer(SqlDataReader reader)
        {
            var customer = new Customer()
            {
                Id = reader.GetInt32(reader.GetOrdinal("personId")),
                Name = reader.GetString(reader.GetOrdinal("personName")),
                Email = reader.GetString(reader.GetOrdinal("personEmail")),
                Address = reader.GetString(reader.GetOrdinal("personAddress")),
                PersonType = reader.GetString(reader.GetOrdinal("personType")),
                Birthday = reader.GetDateTime(reader.GetOrdinal("customerBirthday"))
            };
            return customer;
        }

        public static Warehouse CreateWarehouse(SqlDataReader reader, Product product)
        {
            var warehouse = new Warehouse
            {
                Id = reader.GetInt32(reader.GetOrdinal("warehouseId")),
                Stock = reader.GetInt32(reader.GetOrdinal("warehouseStock")),
                MinStock = reader.GetInt32(reader.GetOrdinal("warehouseMinStock")),
                Product = product
            };
            return warehouse;
        }

        public static PartOrder CreatePartOrder(SqlDataReader reader, Product product)
        {
            var partOrder = new PartOrder()
            {
                Id = reader.GetInt32(reader.GetOrdinal("partOrderId")),
                Product = product,
                Amount = reader.GetInt32(reader.GetOrdinal("partOrderAmount")),
                PartPrice = reader.GetDecimal(reader.GetOrdinal("partOrderPartPrice"))
            };
            return partOrder;
        }

        public static Chain CreateChain(SqlDataReader reader)
        {
            var chain = new Chain
            {
                Id = reader.GetInt32(reader.GetOrdinal("chainId")),
                Name = reader.GetString(reader.GetOrdinal("chainName")),
                CVR = reader.GetString(reader.GetOrdinal("chainCVR"))
            };
            return chain;
        }

        public static Shop CreateShop(SqlDataReader reader)
        {
            var shop = new Shop
            {
                Id = reader.GetInt32(reader.GetOrdinal("shopId")),
                Name = reader.GetString(reader.GetOrdinal("shopName")),
                Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                Cvr = reader.GetString(reader.GetOrdinal("shopCvr"))
            };
            return shop;
        }
    }
}
