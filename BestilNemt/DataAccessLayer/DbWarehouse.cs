using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {
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

        public List<Warehouse> GetAll()
        {
            var warehouses = new List<Warehouse>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username and password1=@password", conn);

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

        public Warehouse Get(int id)
        {
            Warehouse warehouse = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Warehouse WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    warehouse = new Warehouse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock"))
                    };
                    //Warehouse.MinStock = reader.GetInt32(reader.GetOrdinal("minStock"));
                    //warehouse.Shop = reader.GetInt32(reader.GetOrdinal(""));
                    //warehouse.Products = reader.GetInt32(reader.GetOrdinal(""));
                }
            }
            return warehouse;
        }
    }
}
