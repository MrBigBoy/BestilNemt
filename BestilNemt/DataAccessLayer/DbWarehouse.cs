using System.Collections.Generic;
using Models;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DbWarehouse : IDbWarehouse
    {

        public DbWarehouse()
        {

        }

        public void Add(Warehouse warehouse)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Warehouse(stock, minStock)VALUES(@Stock,@MinStock)", conn);
                cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(int id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Warehouse Where id=@id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Warehouse warehouse)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Warehouse SET stock=@stock, minStock=@minStock WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("stock", warehouse.Stock);
                cmd.Parameters.AddWithValue("minStock", warehouse.MinStock);
                cmd.Parameters.AddWithValue("id", warehouse.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Warehouse> GetAll()
        {
            var warehouses = new List<Warehouse>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM LoginTable where username=@username and password1=@password", conn);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var warehouse = new Warehouse
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                            MinStock = reader.GetInt32(reader.GetOrdinal("MinStock")),
                            //Shop = reader.GetInt32(reader.GetOrdinal("")),
                            //Products = reader.GetInt32(reader.GetOrdinal(""))
                        };
                        warehouses.Add(warehouse);
                    }
                }
                else
                {
                    // Error No Lines found
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
