using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    /// <summary>
    /// The Saving class
    /// </summary>
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

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Saving()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SavingPercent = double.NaN;
            Products = new List<Product>();
        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="savingpercent"></param>
        /// <param name="products"></param>
        public Saving(DateTime startdate, DateTime enddate, double savingpercent, List<Product> products)
        {
            StartDate = startdate;
            EndDate = enddate;
            SavingPercent = savingpercent;
            Products = products;
        }

        /// <summary>
        /// Constructor with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="savingpercent"></param>
        /// <param name="products"></param>
        public Saving(int id, DateTime startdate, DateTime enddate, double savingpercent, List<Product> products) : this(startdate, enddate, savingpercent, products)
        {
            Id = id;
        }
    }
}
