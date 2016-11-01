using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace Controller
{
   public class CompanyCtr
    {
        public IDbCompany DbCompany { get; set; }

        public CompanyCtr(IDbCompany dbCustomer)
        {
            DbCompany = dbCustomer;
        }

        public void CreateCompany(Company company)
        {
            DbCompany.CreateCompany(company);
        }

        public List<Company> GetAllCompany()
        {
            return DbCompany.FindAllCompany(); 
        } 
    }
}
