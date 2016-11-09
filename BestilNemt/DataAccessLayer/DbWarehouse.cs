using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {
        /// <summary>
        /// Add a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return 1 if the Warehouse is added, else 0
        /// </returns>
        public int Add(Warehouse warehouse)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Warehouse(stock, minStock)VALUES(@Stock,@MinStock)", conn);
                cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Delete a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if the Warehouse is deleted, else 0
        /// </returns>
        public int Remove(int id)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Warehouse Where id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Update a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return 1 if the Warehouse is updated, else 0
        /// </returns>
        public int Update(Warehouse warehouse)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Warehouse SET stock=@stock, minStock=@minStock WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("id", warehouse.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Return a list of all Warehouses
        /// </summary>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> GetAll()
        {
            var warehouses = new List<Warehouse>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var warehouse = new Warehouse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                        MinStock = reader.GetInt32(reader.GetOrdinal("MinStock"))
                        //Shop = reader.GetInt32(reader.GetOrdinal("")),
                        //Products = reader.GetInt32(reader.GetOrdinal(""))
                    };
                    warehouses.Add(warehouse);
                }
            }
            return warehouses;
        }

        /// <summary>
        /// Return a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Warehouse if found, else null
        /// </returns>
        public Warehouse Get(int id)
        {
            Warehouse warehouse = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Warehouse WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    warehouse = new Warehouse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                        MinStock = reader.GetInt32(reader.GetOrdinal("minStock"))
                    };

                    //warehouse.Shop = reader.GetInt32(reader.GetOrdinal(""));
                    //warehouse.Products = reader.GetInt32(reader.GetOrdinal(""));
                }
            }
            return warehouse;
        }
    }
}
