using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Shop
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public  string Address { get; set; }
        [DataMember]
        public  string CVR { get; set; }
       // [DataMember]
        public List<Person> Persons { get; set; }
        //[DataMember]
        public List <Warehouse> Warehouses { get; set; }

        public Shop()
        {
          
            //Persons = new List<Person>();
            //Warehouses = new List<Warehouse>();
        }
    }
}
