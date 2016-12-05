using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Saving
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public double SavingPercent { get; set; }

        [DataMember]
        private List<Product> Products { get; set; }


        public Saving()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SavingPercent = double.NaN;
            Products = new List<Product>();
        }

        public Saving(int id, DateTime startdate, DateTime enddate, double savingpercent, List<Product> products)
        {
            Id = id;
            StartDate = startdate;
            EndDate = enddate;
            SavingPercent = savingpercent;
            Products = products;
        }

        public Saving(DateTime startdate, DateTime enddate, double savingpercent, List<Product> products)
        {
            StartDate = startdate;
            EndDate = enddate;
            SavingPercent = savingpercent;
            Products = products;
        }
    }
}
