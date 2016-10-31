using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class DbPerson : IDbPerson
    {
        public int Create(Person person)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Person(Name,Email,personType,Address)VALUES(@name,@email,@personType,@address)", conn);
                cmd.Parameters.AddWithValue("name", person.Name);
                cmd.Parameters.AddWithValue("email", person.Email);
                cmd.Parameters.AddWithValue("personType", person.)
                cmd.Parameters.AddWithValue("address", person.Address);
                //var cmd2 = new SqlCommand("INSERT INTO Administator()",conn);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public int Remove(Person person)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM PERSON(id)VALUES(@id)", conn);
                cmd.Parameters.AddWithValue("id", person.Id);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
        public Person Find(int id)
        {
            Person person = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Person WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    person = new Person
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address"))
                    };
                }
            }
            return person;
        }
        public List<Person> FindAllPerson()
        {
            var persons = new List<Person>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Person", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var person = new Person
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Address = reader.GetString(reader.GetOrdinal("address"))
                    };
                    persons.Add(person);
                }
            }
            return persons;
        }

        public int UpdatePerson(Person person)
        {
            int i;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Person SET id=@id, name=@name, email=@email, address=@address WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("id", person.Id);
                cmd.Parameters.AddWithValue("name", person.Name);
                cmd.Parameters.AddWithValue("email", person.Email);
                cmd.Parameters.AddWithValue("address", person.Address);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}
