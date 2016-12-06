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
                Category = reader.GetString(reader.GetOrdinal("productCategory"))
            };
            var j = reader.IsDBNull(reader.GetOrdinal("productImgPath"));
            var saving = reader.IsDBNull(reader.GetOrdinal("productSavingId"));
            product.ImgPath = j ? "NoPhoto.png" : reader.GetString(reader.GetOrdinal("productImgPath"));
            product.SavingId = saving ? 1 : reader.GetInt32(reader.GetOrdinal("productSavingId"));
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
                PersonId = reader.GetInt32(reader.GetOrdinal("cartPersonId"))
            };
            return cart;
        }

        public static Cart CreateCartWithPartOrders(SqlDataReader reader)
        {
            var partOrder = CreatePartOrder(reader);
            var shop = CreateShopWithChain(reader);
            var cart = CreateCart(reader);
            cart.PartOrders.Add(partOrder);
            cart.ShopId = shop.Id;
            cart.ChainId = shop.Chain.Id;
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

        public static PartOrder CreatePartOrder(SqlDataReader reader)
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

        public static Chain CreateChain(SqlDataReader reader)
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

        public static Shop CreateShop(SqlDataReader reader)
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

        public static Shop CreateShopWithChain(SqlDataReader reader)
        {
            var shop = CreateShop(reader);
            var chain = CreateChain(reader);
            shop.Chain = chain;
            return shop;
        }

        public static Saving CreateSaving(SqlDataReader reader)
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
    }
}
