using System;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    /// <summary>
    /// This class is used to build all objects from the database
    /// </summary>
    public class ObjectBuilder
    {
        /// <summary>
        /// Create a product with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Product if builded correct, else null
        /// </returns>
        public static Product CreateProduct(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var product = new Product
                {
                    Id = reader.GetInt32(reader.GetOrdinal("productId")),
                    Name = reader.GetString(reader.GetOrdinal("productName")),
                    Price = reader.GetDecimal(reader.GetOrdinal("productPrice")),
                    Description = reader.GetString(reader.GetOrdinal("productDescription")),
                    Category = reader.GetString(reader.GetOrdinal("productCategory"))
                };
                var j = reader.IsDBNull(reader.GetOrdinal("productImgPath"));
                product.ImgPath = j ? "NoPhoto.png" : reader.GetString(reader.GetOrdinal("productImgPath"));
                return product;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }

        }

        /// <summary>
        /// Create a Admin with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Admin if builded correct, else null
        /// </returns>
        public static Admin CreateAdmin(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var admin = new Admin()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("personId")),
                    Name = reader.GetString(reader.GetOrdinal("personName")),
                    Email = reader.GetString(reader.GetOrdinal("personEmail")),
                    Address = reader.GetString(reader.GetOrdinal("personAddress")),
                    PersonType = reader.GetString(reader.GetOrdinal("personType")),
                    Membernr = reader.GetInt32(reader.GetOrdinal("administratorMemberNr")),
                    ShopId = reader.GetInt32(reader.GetOrdinal("administratorShopId"))
                };
                return admin;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }

        }

        /// <summary>
        /// Create a Cart with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Cart if builded correct, else null
        /// </returns>
        public static Cart CreateCart(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var cart = new Cart
                {
                    Id = reader.GetInt32(reader.GetOrdinal("cartId")),
                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("cartTotalPrice")),
                    PersonId = reader.GetInt32(reader.GetOrdinal("cartPersonId"))
                };
                return cart;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Cart with PartOrders with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Cart if builded correct, else null
        /// </returns>
        public static Cart CreateCartWithPartOrders(SqlDataReader reader)
        {
            // Build the cart
            var cart = CreateCart(reader);
            // If the Cart failed to build, return null
            if (cart == null)
                return null;
            // build the PartOrder
            var partOrder = CreatePartOrder(reader);
            // If the partOrder builded correct
            if (partOrder != null)
            {
                // Add the PartOrder to the Carts PartOrder list
                cart.PartOrders.Add(partOrder);
            }
            // Build the Shop with a Chain
            var shop = CreateShopWithChain(reader);
            // If the Shop failed to build return the cart, else proceed
            if (shop == null)
                return cart;
            // get the shop id
            cart.ShopId = shop.Id;
            // If The shop does have a chain
            if (shop.Chain != null)
            {
                // Set the shops chain id to the carts chain id
                cart.ChainId = shop.Chain.Id;
            }
            return cart;
        }

        /// <summary>
        /// Create a Company with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Company if builded correct, else null
        /// </returns>
        public static Company CreateCompany(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
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
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Customer with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Customer if builded correct, else null
        /// </returns>
        public static Customer CreateCustomer(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
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
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Warehouse with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="product"></param>
        /// <returns>
        /// Warehouse if builded correct, else null
        /// </returns>
        public static Warehouse CreateWarehouse(SqlDataReader reader, Product product)
        {
            // Use try to check if all fields is valid
            try
            {
                var warehouse = new Warehouse
                {
                    Id = reader.GetInt32(reader.GetOrdinal("warehouseId")),
                    Stock = reader.GetInt32(reader.GetOrdinal("warehouseStock")),
                    MinStock = reader.GetInt32(reader.GetOrdinal("warehouseMinStock")),
                    Product = product
                };
                var j = reader.IsDBNull(reader.GetOrdinal("warehouseSavingId"));
                if (!j)
                {
                    warehouse.SavingId = reader.GetInt32(reader.GetOrdinal("warehouseSavingId"));
                }
                else
                {
                    warehouse.SavingId = null;
                }
                return warehouse;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a PartOrder with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// PartOrder if builded correct, else null
        /// </returns>
        public static PartOrder CreatePartOrder(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var partOrder = new PartOrder()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("partOrderId")),
                    Product = CreateProduct(reader),
                    Amount = reader.GetInt32(reader.GetOrdinal("partOrderAmount")),
                    PartPrice = reader.GetDecimal(reader.GetOrdinal("partOrderPartPrice"))
                };
                return partOrder;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Chain with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Chain if builded correct, else null
        /// </returns>
        public static Chain CreateChain(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var chain = new Chain
                {
                    Id = reader.GetInt32(reader.GetOrdinal("chainId")),
                    Name = reader.GetString(reader.GetOrdinal("chainName")),
                    Cvr = reader.GetString(reader.GetOrdinal("chainCVR")),
                    ImgPath = reader.GetString(reader.GetOrdinal("chainImgPath"))
                };
                return chain;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Shop with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Shop if builded correct, else null
        /// </returns>
        public static Shop CreateShop(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var shop = new Shop
                {
                    Id = reader.GetInt32(reader.GetOrdinal("shopId")),
                    Name = reader.GetString(reader.GetOrdinal("shopName")),
                    Address = reader.GetString(reader.GetOrdinal("shopAddress")),
                    OpeningTime = reader.GetString(reader.GetOrdinal("shopOpeningTime")),
                    Cvr = reader.GetString(reader.GetOrdinal("shopCvr"))
                };
                return shop;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }

        /// <summary>
        /// Create a Shop with a Chain with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Shop if builded correct, else null
        /// </returns>
        public static Shop CreateShopWithChain(SqlDataReader reader)
        {
            var shop = CreateShop(reader);
            var chain = CreateChain(reader);
            shop.Chain = chain;
            return shop;
        }

        /// <summary>
        /// Create a Saving with a SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Saving if builded correct, else null
        /// </returns>
        public static Saving CreateSaving(SqlDataReader reader)
        {
            // Use try to check if all fields is valid
            try
            {
                var saving = new Saving
                {
                    Id = reader.GetInt32(reader.GetOrdinal("savingId")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("savingStartDate")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("savingEndDate")),
                    SavingPercent = reader.GetDouble(reader.GetOrdinal("savingPercent"))
                };
                return saving;
            }
            catch (Exception)
            {
                // The build failed, return a null
                return null;
            }
        }
    }
}
