using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbShop : IDbShop
    {
        /// <summary>
        /// AddShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return id of Shop is added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Shop(shopStock, shopMinStock, shopChainId, shopProductId) OUTPUT Inserted.shopId VALUES(@ShopStock, @ShopMinStock, @ShopChainId, @ShopProductId)", conn);
                cmd.Parameters.AddWithValue("ShopStock", shop.Stock);
                cmd.Parameters.AddWithValue("ShopMinStock", shop.MinStock);
                cmd.Parameters.AddWithValue("ShopChainId", shop.Chain.Id);
                cmd.Parameters.AddWithValue("ShopProductId", shop.Product.Id);
                i = (int)cmd.ExecuteScalar();
            }
            return i;
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Shop is deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Shop Where shopId=@ShopId", conn);
                cmd.Parameters.AddWithValue("ShopId", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// UpdateShop a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if the Shop is updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Shop SET shopStock=@ShopStock, shopMinStock=@ShopMinStock, shopChainId=@ShopChainId, shopProductId=ProductId WHERE id=@ShopId", conn);
                cmd.Parameters.AddWithValue("ShopStock", shop.Stock);
                cmd.Parameters.AddWithValue("ShopMinStock", shop.MinStock);
                cmd.Parameters.AddWithValue("ShopChainId", shop.Chain.Id);
                cmd.Parameters.AddWithValue("ShopProductId", shop.Product.Id);
                cmd.Parameters.AddWithValue("ShopId", shop.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Shop if found, else null
        /// </returns>
        public Shop FindShop(int id)
        {
            Shop shop = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Shop, Chain, Product WHERE shopId = @ShopId and chainId = Chain.chainId and productId = Product.productId", conn);
                cmd.Parameters.AddWithValue("ShopId", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var chain = ObjectBuilder.CreateChain(reader);
                    var product = ObjectBuilder.CreateProduct(reader);
                    shop = ObjectBuilder.CreateShop(reader, chain, product);
                }
            }
            return shop;
        }

        /// <summary>
        /// Return a list of all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> FindAllShops()
        {
            var shops = new List<Shop>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Shop, Chain, Product WHERE shopChainId = chainId and shopProductId = productId", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var chain = ObjectBuilder.CreateChain(reader);
                    var product = ObjectBuilder.CreateProduct(reader);
                    var shop = ObjectBuilder.CreateShop(reader, chain, product);
                    shops.Add(shop);
                }
            }
            return shops;
        }
    }
}
