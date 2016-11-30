using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.BestilNemtServiceRef;
namespace WebClient.Models
{
    public class CreatePersonViewModel
    {
        public Login login { get; set; }

        public Customer Customer { get; set; }
    }
}