using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Address { get; set; }
        public  int Cvr { get; set; }
        public List<Person> Persons = new List<Person>();

        public Shop(int id, string name, string address, int cvr)
        {
            Id = id;
            Name = name;
            Address = address;
            Cvr = cvr;
        }
    }
}
