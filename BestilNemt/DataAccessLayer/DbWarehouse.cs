using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class DbWarehouse
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString;
        private SqlConnection Connection { get; set; }

        public DbWarehouse()
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Add(Warehouse warehouse)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Warehouse(stock, minStock)VALUES(@Stock,@MinStock)";
                command.Parameters.AddWithValue("stock", warehouse.Stock);
                command.Parameters.AddWithValue("minStock", warehouse.MinStock);
                command.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public void Remove(int id)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Warehouse Where id=@id";
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public void Update(Warehouse warehouse)
        {
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "UPDATE Warehouse SET stock=@stock, minStock=@minStock WHERE id=@id";
                command.Parameters.AddWithValue("stock", warehouse.Stock);
                command.Parameters.AddWithValue("minStock", warehouse.MinStock);
                command.Parameters.AddWithValue("id", warehouse.Id);
                command.ExecuteNonQuery();
            }
            Connection.Close();
        }

        public List<Warehouse> GetAll()
        {
            List<Warehouse> Warehouses = new List<Warehouse>();
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Warehouse";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Warehouse Warehouse = new Warehouse();
                    Warehouse.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    Warehouse.Stock = reader.GetInt32(reader.GetOrdinal("Stock"));
                    Warehouse.MinStock = reader.GetInt32(reader.GetOrdinal("MinStock"));
                    //warehouse.Shop = reader.GetInt32(reader.GetOrdinal(""));
                    //warehouse.Products = reader.GetInt32(reader.GetOrdinal(""));
                    Warehouses.Add(Warehouse);
                }
            }
            Connection.Close();
            return Warehouses;
        }

        public Warehouse Get(int id)
        {
            Warehouse Warehouse = null;
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Warehouse WHERE id = @id";
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Warehouse = new Warehouse();
                    Warehouse.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    Warehouse.Stock = reader.GetInt32(reader.GetOrdinal("stock"));
                    Warehouse.MinStock = reader.GetInt32(reader.GetOrdinal("minStock"));
                    //warehouse.Shop = reader.GetInt32(reader.GetOrdinal(""));
                    //warehouse.Products = reader.GetInt32(reader.GetOrdinal(""));

                }
            }
            Connection.Close();
            return Warehouse;
        }
    }
}
