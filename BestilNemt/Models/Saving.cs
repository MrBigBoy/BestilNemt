using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        public Saving()
        {
            StartDate = default(DateTime);
            EndDate = default(DateTime);
            SavingPercent = double.NaN;
        }

        public Saving(int id, DateTime startdate, DateTime enddate, double savingpercent)
        {
            Id = id;
            StartDate = startdate;
            EndDate = enddate;
            SavingPercent = savingpercent;
        }

        public Saving(DateTime startdate, DateTime enddate, double savingpercent)
        {
            StartDate = startdate;
            EndDate = enddate;
            SavingPercent = savingpercent;
        }
    }
}
