using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Saving> Savings = new List<Saving>();
        public List<Product> Products = new List<Product>();

        public Category(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
