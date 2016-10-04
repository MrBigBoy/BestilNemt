using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public List<Saving> Savings = new List<Saving>();
       
        public Product(int id, string name, decimal price, int amount, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
            this.Description = description; 

        }

        public Product()
        {


        }

    }
}
