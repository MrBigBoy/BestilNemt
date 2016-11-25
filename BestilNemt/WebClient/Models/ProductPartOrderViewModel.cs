using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Models
{
    public class ProductPartOrderViewModel
    {
        public Product Product { get; set; }
        public int Amount { get; set; }

    }
}