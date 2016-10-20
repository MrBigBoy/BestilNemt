using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbPerson
    {
        private SqlConnection Connection { get; set; }
        private string connectionString = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString;

        public DbPerson()
        {
            Connection = new SqlConnection(connectionString);
        }
        public void Create(Person person)
        {
       
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO PERSON(Name,Email,Address)VALUES(@name,@email,@address)";
                command.Parameters.AddWithValue("name", person.Name);
                command.Parameters.AddWithValue("email", person.Email);
                command.Parameters.AddWithValue("address", person.Address);
                command.ExecuteNonQuery(); 
            }
            Connection.Close();
        }
        public void remove(Person person)
        {

        }
        public Person find(int id)
        {
            Person person = null; 
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Person WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person = new Person();
                    person.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    person.Name = reader.GetString(reader.GetOrdinal("Name"));
                    person.Email = reader.GetString(reader.GetOrdinal("Email"));
                    person.Address = reader.GetString(reader.GetOrdinal("Address"));
                }

            }

            Connection.Close();
            return person; 
        }
        public List<Person> FindAllPerson()
        {
            List<Person> persons = new List<Person>();
            Connection.Open();
            using (SqlCommand command = Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Person";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                   Person person = new Person();
                    person.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    person.Name = reader.GetString(reader.GetOrdinal("Name"));
                    person.Email = reader.GetString(reader.GetOrdinal("Email"));
                    person.Address = reader.GetString(reader.GetOrdinal("Address"));
                    persons.Add(person);
                }

            }

            Connection.Close();
            return persons;
        }

        public void updatePerson(Person person)
        {

        }
    }
}
